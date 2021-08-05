using Microsoft.AspNetCore.Mvc;
using SwaggerDemoApi.Extension;
using SwaggerDemoApi.Menu;
using System;
using System.ComponentModel.DataAnnotations;

namespace SwaggerDemoApi.Controllers
{

    public class Req
    {
        public Guid Id { get; set; }
    }

    /// <summary>
    /// Main api
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("show/guid")]
        public Guid TestGuid(Guid id)
        {
            return id;
        }

        [HttpPost("show/guid")]
        public Guid TestShowGuid([FromBody] Req req)
        {
            return req.Id;
        }

        [HttpPost("validReq")]
        public string validReq([FromBody]InfoReq req)
        {
            return "ok";
        }

        /// <summary>
        /// 获取枚举
        /// </summary>
        /// <param name="arg">
        ///     <para>1 - 测试</para>
        ///     <para>2 - 测试2</para>
        /// </param>
        /// <param name="level"></param>
        /// <returns></returns>
        [HttpGet("menu")]
        public string GetMenu(string arg, Level level)
        {
            return level.GetDescription();
        }

        /// <summary>
        /// 获取枚举
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("menu")]
        public string GetMenu([FromBody] MenuReq req)
        {
            return req.Level.GetDescription();
        }
        /// <summary>
        /// 获取枚举
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("menu2")]
        public NewLevel GetMenu([FromBody] NewMenuReq req)
        {
            return req.Level;
        }
        /// <summary>
        /// 获取枚举
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        [HttpPost("{level}")]
        public NewLevel GetMenu(NewLevel level)
        {
            return level;
        }

    }

    public class InfoReq
    {
        [Required]
        public string Name { get; set; }
        [StringLength(0, ErrorMessage = "文字太长了")]
        [Required]
        public string Id { get; set; }
    }

    public class NewMenuReq
    {
        public NewLevel Level { get; set; }

        public string Arg { get; set; }
    }

    public class MenuReq
    {
        public Level Level { get; set; }

        public string Arg { get; set; }
    }

}
