using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioPagina90.PageObjectPattern.Helpers
{
    public static class WaitHelper
    {
        public static void WaitForCondition(Func<bool> condition, int msTimeout = 4000)
        {
            // este codigo es muy util para controlar l
            var stopWatch = new Stopwatch(); // definimos una variable de tipo Stopwatch

            stopWatch.Start(); //iniciamos la variable.
            Exception? ex;
            do
            {
                try
                {
                    ex = null;
                    if (condition())
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    ex = e;
                }
            } while (stopWatch.ElapsedMilliseconds < msTimeout);
            stopWatch.Stop();
            if (ex != null)
            {
                throw new TimeoutException("Error executing the condition", ex);
            }
            throw new TimeoutException("Error the condition was false", ex);// si la  condicion es fase siempre

        }
    }
}
