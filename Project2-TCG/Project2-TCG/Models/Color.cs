using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_TCG.Models
{
    public class Color
    {
        /// <summary>
        /// empty constructor
        /// </summary>
        public Color() { }
        /// <summary>
        /// constructor for retrieving color from DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Color(int id, string name) {
            this.Id = id;
            this.ColorName = name;
        }
        /// <summary>
        /// retrieving color from database
        /// </summary>
        int Id { get; set; }
        string ColorName { get; set; }
    }
}
