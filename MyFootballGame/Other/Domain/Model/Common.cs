using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootballGame.Other.Domain.Model
{
    public class Common
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public CommonStatusEnum Status { get; set; }

    }
    public enum CommonStatusEnum
    {
        Inactive,
        Active,
    }
}
