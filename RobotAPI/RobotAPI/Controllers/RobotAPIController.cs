using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RobotControlLib;

namespace RobotAPI.Controllers
{
    [ApiController]
    [Route("/robot")]
    public class RobotAPIController : Controller
    {
        private RobotController _RobotController;
        public RobotAPIController()
        {
            _RobotController = new RobotController("192.168.0.60", 10001);
        }
        [HttpGet()]
        public string Get()
        {
            return "This is the api for DrRobot 4x4 jaguar";
        }

        [HttpPost()]
        public ActionResult Post([FromBody] Decision decision)
        {
            _RobotController.MoveRobot(decision);
            return Ok("Command: move " + decision.Command + " executed");
        }
    }
}
