using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Descripción breve de WebServiceCalculator
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    // En caso de tener varios metodos con el mismo nombre se utiliza MessageName, ademas se  pone ConformsTo = WsiProfiles.None
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceCalculator : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod (MessageName ="HellowWorld1")]
        public string HelloWorld(String a)
        {
            return a;
        }
        /**Description: Pequena descripcion del WebService 
         * Cache duration: Impide la insercion de valores duplicados en un lapso de tiempo 
         */
        [WebMethod(EnableSession = true, Description = "This sum 2 Numbers", CacheDuration = 5)]
        public Int32 Add(int firtNumber, int lastNumber)
        {
            List<String> calculations;
            if (Session["CALCULATIONS"] == null)
            {
                calculations = new List<String>();
            }
            else
            {
                calculations = (List<String>)Session["CALCULATIONS"];
            }
            String strRecentCalculation = firtNumber.ToString() + " + " + lastNumber.ToString() + " = " +
                (firtNumber + lastNumber).ToString();
            calculations.Add(strRecentCalculation);
            Session["CALCULATIONS"] = calculations;
            return firtNumber + lastNumber;
        }
        [WebMethod(EnableSession = true, Description ="This Metod Sum Det A session array of metod Add")]
        public List<String> GetCalculations()
        {
            if(Session["CALCULATIONS"] == null)
            {
                List<String> calculations = new List<string>();
                calculations.Add("You dont have eny calculation");
                return calculations;
            }
            else
            {
                return (List<String>)Session["CALCULATIONS"];
            }
        }
    }
}
