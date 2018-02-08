﻿/*
 * Copyright (c) 2018 Demerzel Solutions Limited
 * This file is part of the Nethermind library.
 *
 * The Nethermind library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * The Nethermind library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using Nevermind.Discovery.RoutingTable;

namespace Nevermind.Discovery.Messages
{
    public class MessageFactory : IMessageFactory
    {
        public Message CreateMessage(MessageType messageType, Node destination)
        {
            switch (messageType)
            {
                case MessageType.FindNode:
                    return CreateFindNodeMessage(destination);
                case MessageType.Ping:
                    return CreatePingMessage(destination);
                case MessageType.Pong:
                    return CreatePongMessage(destination);
                case MessageType.Neighbors:
                    return CreateNeighborsMessage(destination);
                default:
                    throw new Exception($"Unsupported message type: {messageType}");
            }
        }

        private Message CreateFindNodeMessage(Node destination)
        {
            return new FindNodeMessage
            {
                Type = new[] {(byte)MessageType.FindNode},
                Host = destination.Host,
                Port = destination.Port
            };
        }

        private Message CreatePingMessage(Node destination)
        {
            return new PingMessage
            {
                Type = new[] { (byte)MessageType.Ping },
                Host = destination.Host,
                Port = destination.Port
            };
        }

        private Message CreatePongMessage(Node destination)
        {
            return new PongMessage
            {
                Type = new[] { (byte)MessageType.Pong },
                Host = destination.Host,
                Port = destination.Port
            };
        }

        private Message CreateNeighborsMessage(Node destination)
        {
            return new NeighborsMessage
            {
                Type = new[] { (byte)MessageType.Neighbors },
                Host = destination.Host,
                Port = destination.Port
            };
        }
    }
}