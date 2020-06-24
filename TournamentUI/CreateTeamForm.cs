using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TournamentLibrary.Configuration;
using TournamentLibrary.Models;

namespace TournamentUI
{
    public partial class CreateTeamForm : Form
    {
        public List<PersonModel> AvailableTeamMembers = GlobalConfig.Connections.GetAllPersons();
        public List<PersonModel> SelectedTeamMembers = new List<PersonModel>();
        private ITeamRequestor teamRequestor;

        public CreateTeamForm(ITeamRequestor requestor)
        {
            InitializeComponent();
            teamRequestor = requestor;
            //CreateSampleData();
            WireUpList();
        }

        private void WireUpList()
        {
            SelectTeamMemberDropDown.DataSource = null;

            SelectTeamMemberDropDown.DataSource = AvailableTeamMembers;
            SelectTeamMemberDropDown.DisplayMember = "FullName";

            TeamMembersListbox.DataSource = null;

            TeamMembersListbox.DataSource = SelectedTeamMembers;
            TeamMembersListbox.DisplayMember = "FullName";
        }

        private void CreateSampleData()
        {
            AvailableTeamMembers.Add(new PersonModel{ FirstName = "Person1FN", LastName = "Person1LN"});
            AvailableTeamMembers.Add(new PersonModel{ FirstName = "Person2FN", LastName = "Person2LN" });

            SelectedTeamMembers.Add(new PersonModel { FirstName = "Person3FN", LastName = "Person3LN" });
            SelectedTeamMembers.Add(new PersonModel { FirstName = "Person4FN", LastName = "Person4LN" });
        }

        private void CreateNewMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel person = new PersonModel();
                person.FirstName = FirstNameValue.Text;
                person.LastName = LastNameValue.Text;
                person.Email = EmailValue.Text;
                person.PhoneNumber = PhoneNumberValue.Text;
                // связываем с БД  
                GlobalConfig.Connections.CreatePerson(person);

                SelectedTeamMembers.Add(person);
                WireUpList();

                // очищаем форму
                FirstNameValue.Text = "";
                LastNameValue.Text = "";
                EmailValue.Text = "";
                PhoneNumberValue.Text = "";
            }
            else
            {
                MessageBox.Show("Incorrect information. Please fill in the fields carefully");
            }
        }

        private bool ValidateForm()
        {
            if (FirstNameValue.Text.Length == 0)
            {
                return false;
            }
            if (LastNameValue.Text.Length == 0)
            {
                return false;
            }
            if (EmailValue.Text.Length == 0)
            {
                return false;
            }
            if (PhoneNumberValue.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void AddTeamMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel) SelectTeamMemberDropDown.SelectedItem;

            if (p != null)
            {
                AvailableTeamMembers.Remove(p);
                SelectedTeamMembers.Add(p);
                WireUpList(); 
            }
        }

        private void RemoveMembersButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)TeamMembersListbox.SelectedItem;
            if (p != null)
            {
                SelectedTeamMembers.Remove(p);
                AvailableTeamMembers.Add(p);
                WireUpList();
            }
        }

        private void CreateTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel team = new TeamModel();
            team.TeamName = TeamNameValue.Text;
            team.TeamMembers = SelectedTeamMembers;

            GlobalConfig.Connections.CreateTeam(team);

            teamRequestor.TeamComplete(team);
            this.Close();
        }
    }
}