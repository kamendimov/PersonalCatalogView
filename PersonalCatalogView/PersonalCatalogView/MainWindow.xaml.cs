using PersonalCatalogView.ObjectModel;
using PersonalCatalogView.Service;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace PersonalCatalogView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MAX_IBAN_GROUP_LENGTH = 4;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.FirstName = FirstName.Text;
            person.SurName = Surname.Text;
            person.Dob = Dob.SelectedDate;
            person.Address = Address.Text;
            person.PhoneNumber = PhoneNumber.Text;
            person.IBAN = IBAN1.Text + IBAN2.Text + IBAN3.Text + IBAN4.Text + IBAN5.Text + IBAN6.Text;

            PERSIST_DATA_ERROR _DATA_ERROR = person.Validate();
            if (_DATA_ERROR == PERSIST_DATA_ERROR.SUCCESS)
            {
                IPersonWriteService personWriteService = new PersonWriteService();
                IPersonCommand personCommand = new PersonCommand(personWriteService);
                person.Id = -1;
                int Id;
                if (int.TryParse(PersonId.Text, out Id))
                {
                    person.Id = Id;
                }
                if (person.Id > 0)
                {
                    personCommand.UpdatePerson(person);
                }
                else
                {
                    IPersonReadService personReadService = new PersonReadService();
                    IPersonQueries personQueries = new PersonQueries(personReadService);

                    Person checkPerson = personQueries.FindPersonByPhoneNumber(person.PhoneNumber);
                    if(checkPerson == null)
                    {
                        checkPerson = personQueries.FindPersonByIBAN(person.IBAN);
                    }

                    if (checkPerson == null)
                    {
                        personCommand.SavePerson(person);
                    }
                    else
                    {
                        ShowMsgBox(PERSIST_DATA_ERROR.PERSON_EXISTS);
                    }
                }
            }
            else
            {
                ShowMsgBox(_DATA_ERROR);
            }
        }

        private void IBAN1_TextChange(object sender, TextChangedEventArgs e)
        {
            IBAN1.Text = SetLastSymbolToUpperCase(IBAN1.Text);
            SetCursorPosition(IBAN1);
            if (IBAN1.Text.Length == MAX_IBAN_GROUP_LENGTH)
            {
                IBAN2.Focus();
            }
        }

        private void IBAN2_TextChanged(object sender, TextChangedEventArgs e)
        {
            IBAN2.Text = SetLastSymbolToUpperCase(IBAN2.Text);
            SetCursorPosition(IBAN2);
            if (IBAN2.Text.Length == MAX_IBAN_GROUP_LENGTH)
            {
                IBAN3.Focus();
            }
        }

        private void IBAN3_TextChanged(object sender, TextChangedEventArgs e)
        {
            IBAN3.Text = SetLastSymbolToUpperCase(IBAN3.Text);
            SetCursorPosition(IBAN3);
            if (IBAN3.Text.Length == MAX_IBAN_GROUP_LENGTH)
            {
                IBAN4.Focus();
            }
        }

        private void IBAN4_TextChanged(object sender, TextChangedEventArgs e)
        {
            IBAN4.Text = SetLastSymbolToUpperCase(IBAN4.Text);
            SetCursorPosition(IBAN4);
            if (IBAN4.Text.Length == MAX_IBAN_GROUP_LENGTH)
            {
                IBAN5.Focus();
            }
        }

        private void IBAN5_TextChanged(object sender, TextChangedEventArgs e)
        {
            IBAN5.Text = SetLastSymbolToUpperCase(IBAN5.Text);
            SetCursorPosition(IBAN5);
            if (IBAN5.Text.Length == MAX_IBAN_GROUP_LENGTH)
            {
                IBAN6.Focus();
            }
        }

        private void IBAN6_TextChanged(object sender, TextChangedEventArgs e)
        {
            IBAN6.Text = SetLastSymbolToUpperCase(IBAN6.Text);
            SetCursorPosition(IBAN6);
        }

        private string SetLastSymbolToUpperCase(string Parameter)
        {
            String UpperCaseParameter = Parameter;
            return UpperCaseParameter.ToUpperInvariant();
        }

        private void SetCursorPosition(TextBox textBox)
        {
            textBox.Select(textBox.Text.Length, 0);
        }

        private void SearchById_Click(object sender, RoutedEventArgs e)
        {
            IPersonReadService personReadService = new PersonReadService();
            IPersonQueries personQueries = new PersonQueries(personReadService);
            int Id;
            if (int.TryParse(PersonId.Text, out Id))
            {
                Person person = personQueries.FindPersonById(Id);
                if (person != null)
                {
                    InitializeInterfaceBySelectedPerson(person);
                }
                else
                {
                    ShowMsgBox(PERSIST_DATA_ERROR.MISSING_OBJECT);
                }
            }
            else
            {
                ShowMsgBox(PERSIST_DATA_ERROR.INVALID_PERSON_ID);
            }
        }

        private void SearchByFirstName_Click(object sender, RoutedEventArgs e)
        {
            IPersonReadService personReadService = new PersonReadService();
            IPersonQueries personQueries = new PersonQueries(personReadService);
            
            if (FirstName.Text.Length > 0)
            {
                Person person = personQueries.FindPersonByFirstName(FirstName.Text);
                if (person != null)
                {
                    InitializeInterfaceBySelectedPerson(person);
                }
                else
                {
                    ShowMsgBox(PERSIST_DATA_ERROR.MISSING_OBJECT);
                }
            }
            else
            {
                ShowMsgBox(PERSIST_DATA_ERROR.INVALID_FIRST_NAME);
            }
        }

        private void SearchByPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            IPersonReadService personReadService = new PersonReadService();
            IPersonQueries personQueries = new PersonQueries(personReadService);

            if (PhoneNumber.Text.Length > 0)
            {
                Person person = personQueries.FindPersonByPhoneNumber(PhoneNumber.Text);
                if (person != null)
                {
                    InitializeInterfaceBySelectedPerson(person);
                }
                else
                {
                    ShowMsgBox(PERSIST_DATA_ERROR.MISSING_OBJECT);
                }
            }
            else
            {
                ShowMsgBox(PERSIST_DATA_ERROR.INVALID_FIRST_NAME);
            }
        }

        private void SearchByIBAN_Click(object sender, RoutedEventArgs e)
        {
            IPersonReadService personReadService = new PersonReadService();
            IPersonQueries personQueries = new PersonQueries(personReadService);

            string IBAN = IBAN1.Text + IBAN2.Text + IBAN3.Text + IBAN4.Text + IBAN5.Text + IBAN6.Text;

            if (IBAN.Length > 0)
            {
                Person person = personQueries.FindPersonByIBAN(IBAN);
                if(person != null)
                {
                    InitializeInterfaceBySelectedPerson(person);
                }
                else
                {
                    ShowMsgBox(PERSIST_DATA_ERROR.MISSING_OBJECT);
                }
            }
            else
            {
                ShowMsgBox(PERSIST_DATA_ERROR.INVALID_IBAN);
            }
        }

        private void InitializeInterfaceBySelectedPerson(Person person)
        {
            PersonId.Text = person.Id.ToString();
            FirstName.Text = person.FirstName;
            Surname.Text = person.SurName;
            Dob.SelectedDate = person.Dob;
            Address.Text = person.Address;
            PhoneNumber.Text = person.PhoneNumber;

            if(person.IBAN.Length >= Person.IBAN_LENGTH)
            {
                IBAN1.Text = person.IBAN.Substring(0, 4);
                IBAN2.Text = person.IBAN.Substring(4, 4);
                IBAN3.Text = person.IBAN.Substring(8, 4);
                IBAN4.Text = person.IBAN.Substring(12, 4);
                IBAN5.Text = person.IBAN.Substring(16, 4);
                IBAN6.Text = person.IBAN.Substring(20, 2);
            }
        }

        private void ShowMsgBox(PERSIST_DATA_ERROR _DATA_ERROR)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            FieldInfo fieldInfo = _DATA_ERROR.GetType().GetField(_DATA_ERROR.ToString());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            MessageBox.Show(attributes[0].Description);
        }
    }
}
