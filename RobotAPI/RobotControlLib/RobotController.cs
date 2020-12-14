using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotControlLib
{
    public class RobotController
    {
        private DrRobotComm robot;
        public RobotController(string ip, int port)
        {
            robot = new DrRobotComm();
            robot.StartClient(ip, port);
        }
        public bool DisableEstop() 
        {
            return robot.SendCommand("MMW !MG");
        }

        public bool EnableEstop()
        {
            return robot.SendCommand("MMW !EX");
        }

        public bool MoveRobot(Decision decision)
        {
            DisableEstop();
            switch (decision.Command)
            {
                case "forward":
                    robot.SendCommand("MMW !M 200 -200");
                    for (int i = 0; i < 5; i++)
                    {
                        robot.SendCommand("PING");
                        Thread.Sleep(100);
                    }
                    break;
                case "backward":
                    robot.SendCommand("MMW !M -200 200");
                    for (int i = 0; i < 5; i++)
                    {
                        robot.SendCommand("PING");
                        Thread.Sleep(100);
                    }
                    break;
                case "left":
                    robot.SendCommand("MMW !M -200 -200");
                    for (int i = 0; i < 5; i++)
                    {
                        robot.SendCommand("PING");
                        Thread.Sleep(100);
                    }
                    break;
                case "right":
                    robot.SendCommand("MMW !M 200 200");
                    for (int i = 0; i < 5; i++)
                    {
                        robot.SendCommand("PING");
                        Thread.Sleep(100);
                    }
                    break;
                default:
                    break;
            }
            EnableEstop();
            return true;
        }
    }
}
