using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;


namespace Energieweb.Helpers
{
    public class Result
    {
        private ArrayList dataset;
        private Boolean succes;
        private String message;

        public string Message { get => message; set => message = value; }
        public bool Succes { get => succes; set => succes = value; }
        public ArrayList Dataset { get => dataset; set => dataset = value; }

        public object GetFirstValue()
        {
            return this.dataset[0];
        }
    }
}