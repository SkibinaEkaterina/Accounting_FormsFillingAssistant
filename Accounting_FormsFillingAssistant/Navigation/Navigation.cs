using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Accounting_FormsFillingAssistant
{
    public class Navigation
    {
        /// <summary>
        /// Поле - Сервис навигации
        /// </summary>
        private NavigationService mns_NavigationService;

        /// <summary>
        /// Свойство Сервиса навигации
        /// </summary>
        public NavigationService AppNavigationService
        {
            get
            {
                return mns_NavigationService;
            }
            set
            {
                if (mns_NavigationService != null)
                {
                    mns_NavigationService.Navigated -= NavigationService_Navigated;
                }

                mns_NavigationService = value;
                mns_NavigationService.Navigated += NavigationService_Navigated;
            }
        }




        /// <summary>
        /// Действие на событие которое возникает, когда содержимое, к которому 
        /// осуществляется переход, найдено и доступно через свойство Content,
        /// хотя его загрузка, возможно, еще не завершена.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
            var page = e.Content as Page;

            if (page == null)
            {
                return;
            }

            page.DataContext = e.ExtraData;
        }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="navigationService"> Сервис навигации контрола, в котором будем осуществлять навигацию. </param>
        public Navigation(NavigationService navigationService)
        {
            AppNavigationService = navigationService;
        }

    }
}
