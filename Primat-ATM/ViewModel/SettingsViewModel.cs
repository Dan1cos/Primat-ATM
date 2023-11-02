using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        public ICardService CardService { get; set; }
        public SettingsViewModel(ICardService cardService)
        {
            CardService = cardService;

        }
    }
}
