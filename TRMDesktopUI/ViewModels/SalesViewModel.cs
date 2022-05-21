using Caliburn.Micro;
using System.ComponentModel;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get { return _products; }
            set 
            {

                if (value == _products) return;
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {

                if (value == _cart) return;
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set 
            { 
                _itemQuantity = value; 
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public string SubTotal
        {
            get 
            {
                // TODO: Replace with calculation
                return "$0.00"; 
            }
        }

        public string Total
        {
            get
            {
                // TODO: Replace with calculation
                return "$0.00";
            }
        }

        public string Tax
        {
            get
            {
                // TODO: Replace with calculation
                return "$0.00";
            }
        }

        public bool CanAddToCart 
        { 
            get
            {
                bool output = false;

                // Make sure something is selected
                // Make sure there is some quantity
                //if ()
                //{
                //    output = true;
                //}

                return output;
            }
        }

        public void AddToCart()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                // Make sure something is selected
                //if ()
                //{
                //    output = true;
                //}

                return output;
            }
        }

        public void RemoveFromCart()
        {

        }

        public void AddToCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                // Make sure something is in the cart
                //if ()
                //{
                //    output = true;
                //}

                return output;
            }
        }

        public void CheckOut()
        {

        }
    }
}