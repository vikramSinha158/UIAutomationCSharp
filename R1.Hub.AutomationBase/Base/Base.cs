using R1.Automation.UI.core.Commons;
using System;
using R1.Hub.AutomationBase.Common;

namespace R1.Hub.AutomationBase.Base
{
    public class Base
    {

        public DriverContext _driverContext;
        public Base(DriverContext driverContext)
        {
            _driverContext = driverContext;           
        }

        /// <summary>
        /// Generic method to create instance of class
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns>Return the instence for current class</returns>
        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }

        public CommonUtility commonUtil = new CommonUtility();
        public Utils util = new Utils();
    }
}
