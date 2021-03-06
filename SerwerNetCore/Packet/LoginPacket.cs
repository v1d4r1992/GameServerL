﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SerwerNetCore.Packet
{
	class LoginPacket : IPacket
	{
		public PacketData Packet { get; set; }

		public void Execute(User user)
		{
			string nick = ASCIIEncoding.ASCII.GetString(Packet.buffer, 2, Packet.buffer[2]);

			if (Sessions.SessionsInstance.sessionList.Exists(x => x.User.NickName == nick))
			{
				Sessions.SessionsInstance.sessionList.Where(x => x.User == user).FirstOrDefault().Connection.SendAsyncFunction(new byte[] { 0x90, 0x01 });
			}
			else
			{
				user.NickName = nick;
			}
		}
	}
}
