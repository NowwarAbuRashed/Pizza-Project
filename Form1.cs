using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
            {
                lblSize.Text=rbSmall.Text;
            }
            if(rbMeduim.Checked)
            {
                lblSize.Text=rbMeduim.Text;
            }
            if(rbLarg.Checked)
            {
                lblSize.Text = rbLarg.Text;
            }

        }
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarg_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rbThinCrust.Checked)
            {
                lblCrustType.Text=rbThinCrust.Text;
            }
            if(rbThinkCrust.Checked)
            {
                lblCrustType.Text =rbThinkCrust.Text;
            }
        }
        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }


        void UpdateWhereToEat()
        {
            if(rbEatIn.Checked)
            {
                lblWereToEate.Text=rbEatIn.Text;
            }
            if(rbTakeOut.Checked)
            {
                lblWereToEate.Text=rbTakeOut.Text;
            }
        }
        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        void UpdateToppings()
        {
            UpdateTotalPrice();
            string Toppings = "";
            if(chkExtraChees.Checked)
            {
                Toppings +=(chkExtraChees.Text);
            }
            if(chkMushrooms.Checked)
            {
                Toppings+= (", " + chkMushrooms.Text);
            }
            if(chkTomatoes.Checked)
            {
                Toppings+=(", " + chkTomatoes.Text);
            }
            if(chkOnion.Checked)
            {
                Toppings+=(", " + chkOnion.Text);
            }
            if(chkOlives.Checked)
            {
                Toppings+=(", " + chkOlives.Text);
            }
            if(chkGreenPeppers.Checked)
            {
                Toppings+=(", " +chkGreenPeppers.Text);
            }

            if(Toppings.StartsWith(","))
            {
                Toppings = Toppings.Substring(1,Toppings.Length-1);
            }
            if(Toppings=="")
            {
                Toppings = "No Toppings";
            }

            lblTopings.Text = Toppings;

        }
        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

       float GetSelecyedSizePrice()
        {
           
            if (rbSmall.Checked)
            {
                return Convert.ToSingle(rbSmall.Tag);
            }
            else if(rbMeduim.Checked)
            {
                return Convert.ToSingle(rbMeduim.Tag);
            }
            else
            {
                return Convert.ToSingle(rbLarg.Tag);
            }
        }

        float GetSelectedToppingsPrice()
        {
            float Price = 0;
            if (chkExtraChees.Checked)
            {
                Price += (Convert.ToSingle( chkExtraChees.Tag));
            }
            if (chkMushrooms.Checked)
            {
                Price += Convert.ToSingle( chkMushrooms.Tag);
            }
            if (chkTomatoes.Checked)
            {
                Price +=  Convert.ToSingle(chkTomatoes.Tag);
            }
            if (chkOnion.Checked)
            {
                Price += Convert.ToSingle(chkOnion.Tag);
            }
            if (chkOlives.Checked)
            {
                Price += Convert.ToSingle(chkOlives.Tag);
            }
            if (chkGreenPeppers.Checked)
            {
                Price += Convert.ToSingle(chkGreenPeppers.Tag);
            }

            return Price;
        }
        float GetSelectedCrustType()
        {
            if(rbThinCrust.Checked)
            {
                return Convert.ToSingle(rbThinCrust.Tag);
            }
            else
            {
                return Convert.ToSingle(rbThinkCrust.Tag);
            }
        }

        float CalculateTotalPricce()
        {

            return GetSelectedToppingsPrice() + GetSelecyedSizePrice()+ GetSelectedCrustType();
        }

        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" +CalculateTotalPricce()*((float)NumberOfPizza.Value);
        }

        private void butOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                butOrderPizza.Enabled = false;
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbCrustType.Enabled = false;
                gbWhereToEat.Enabled = false;
                NumberOfPizza.Enabled=false;

            }
            else

                MessageBox.Show("Update your order", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        void ResetForm()
        {

            //reset Groups
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;

            //reset Size
            rbMeduim.Checked = true;

            //reset Toppings.
            chkExtraChees.Checked = false;
            chkOnion.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkGreenPeppers.Checked = false;

            //reset CrustType
            rbThinCrust.Checked = true;

            //reset Where to Eat
            rbEatIn.Checked = true;

            //Reset Order Button
            butOrderPizza.Enabled = true;

            NumberOfPizza.Enabled=true;
            NumberOfPizza.Value = 1;

        }
       
        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            ResetForm();
            UpdateOrderSummary();
        }
        private void butResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void NumberOfPizza_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }
    }
}
