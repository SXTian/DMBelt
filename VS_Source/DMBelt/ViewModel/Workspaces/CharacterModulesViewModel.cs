using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using DMBelt.DataAccess;
using DMBelt.Model.Character;
using DMBelt.Properties;

namespace DMBelt.ViewModel.Workspaces
{
    /// <summary>
    /// A UI wrapper for a Character object.
    /// </summary>
    public class CharacterModulesViewModel : WorkspaceViewModel, IDataErrorInfo
    {
        //  Fields
        CharacterViewModel cvm;
        Character m_character;
        bool m_propertyChanged;

        CommandInterface c_saveCommand;
        CommandInterface c_addFeatCommand;
     
        //  Constructor
        public CharacterModulesViewModel(CharacterViewModel viewModel)
        {
            cvm = viewModel;
            m_character = new Character(cvm.Character);
            m_propertyChanged = false;
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (m_propertyChanged == false)
            {
                m_propertyChanged = true;
                base.OnPropertyChanged("DisplayName");
            }

        }

        //  Character Properties
        public string Name
        {
            get { return (string)m_character.Modules.Profile.GetProperty("Name"); }
            set { if (Name != value) { m_character.Modules.Profile.SetProperty("Name", value); OnPropertyChanged("Name"); } }
        }
        public bool IsPC
        {
            get { return (bool)m_character.Modules.Profile.GetProperty("IsPC"); }
            set { if (IsPC != value) { m_character.Modules.Profile.SetProperty("IsPC", value); OnPropertyChanged("IsPC"); } }
        }
        public bool IsNPC
        {
            get { return (bool)m_character.Modules.Profile.GetProperty("IsNPC"); }
            set { if (IsNPC != value) { m_character.Modules.Profile.SetProperty("IsNPC", value); OnPropertyChanged("IsNPC"); } }
        }
        public bool IsFemale
        {
            get { return (bool)m_character.Modules.Profile.GetProperty("IsFemale"); }
            set { if (IsFemale != value) { m_character.Modules.Profile.SetProperty("IsFemale", value); OnPropertyChanged("IsFemale"); } }
        }
        public bool IsMale
        {
            get { return (bool)m_character.Modules.Profile.GetProperty("IsMale"); }
            set { if (IsMale != value) { m_character.Modules.Profile.SetProperty("IsMale", value); OnPropertyChanged("IsMale"); } }
        }
        public string Race
        {
            get { return (string)m_character.Modules.Race.GetProperty("Race"); }
            set { if (Race != value) { m_character.Modules.Race.SetProperty("Race", value); OnPropertyChanged("Race"); } }
        }
        public string Class
        {
            get { return (string)m_character.Modules.Class.GetProperty("Class"); }
            set { if (Class != value) { m_character.Modules.Class.SetProperty("Class", value); OnPropertyChanged("Class"); } }
        }
        public int Level
        {
            get { return (int)m_character.Modules.Class.GetProperty("Level"); }
            set { if (Level != value) { m_character.Modules.Class.SetProperty("Level", value); OnPropertyChanged("Level"); } }
        }
        public int Experience
        {
            get { return (int)m_character.Modules.Class.GetProperty("Experience"); }
            set { if (Experience != value) { m_character.Modules.Class.SetProperty("Experience", value); OnPropertyChanged("Experience"); } }
        }

        public int STR
        {
            get { return (int)m_character.Modules.GetAbilityModule("STR").GetProperty("Score"); }
            set { if (STR != value) { m_character.Modules.GetAbilityModule("STR").SetProperty("Score", value); OnPropertyChanged("STR"); } }
        }
        public int DEX
        {
            get { return (int)m_character.Modules.GetAbilityModule("DEX").GetProperty("Score"); }
            set { if (DEX != value) { m_character.Modules.GetAbilityModule("DEX").SetProperty("Score", value); OnPropertyChanged("DEX"); } }
        }
        public int CON
        {
            get { return (int)m_character.Modules.GetAbilityModule("CON").GetProperty("Score"); }
            set { if (CON != value) { m_character.Modules.GetAbilityModule("CON").SetProperty("Score", value); OnPropertyChanged("CON"); } }
        }
        public int INT
        {
            get { return (int)m_character.Modules.GetAbilityModule("INT").GetProperty("Score"); }
            set { if (INT != value) { m_character.Modules.GetAbilityModule("INT").SetProperty("Score", value); OnPropertyChanged("INT"); } }
        }
        public int WIS
        {
            get { return (int)m_character.Modules.GetAbilityModule("WIS").GetProperty("Score"); }
            set { if (WIS != value) { m_character.Modules.GetAbilityModule("WIS").SetProperty("Score", value); OnPropertyChanged("WIS"); } }
        }
        public int CHA
        {
            get { return (int)m_character.Modules.GetAbilityModule("CHA").GetProperty("Score"); }
            set { if (CHA != value) { m_character.Modules.GetAbilityModule("CHA").SetProperty("Score", value); OnPropertyChanged("CHA"); } }
        }

        public int Acrobatics
        {
            get { return (int)m_character.Modules.GetSkillModule("Acrobatics").GetProperty("Rank"); }
            set { if (Acrobatics != value) { m_character.Modules.GetSkillModule("Acrobatics").SetProperty("Rank", value); OnPropertyChanged("Acrobatics"); } }
        }
        public int Appraise
        {
            get { return (int)m_character.Modules.GetSkillModule("Appraise").GetProperty("Rank"); }
            set { if (Appraise != value) { m_character.Modules.GetSkillModule("Appraise").SetProperty("Rank", value); OnPropertyChanged("Appraise"); } }
        }
        public int Bluff
        {
            get { return (int)m_character.Modules.GetSkillModule("Bluff").GetProperty("Rank"); }
            set { if (Bluff != value) { m_character.Modules.GetSkillModule("Bluff").SetProperty("Rank", value); OnPropertyChanged("Appraise"); } }
        }
        public int Climb
        {
            get { return (int)m_character.Modules.GetSkillModule("Climb").GetProperty("Rank"); }
            set { if (Climb != value) { m_character.Modules.GetSkillModule("Climb").SetProperty("Rank", value); OnPropertyChanged("Climb"); } }
        }
        public int Craft
        {
            get { return (int)m_character.Modules.GetSkillModule("Craft").GetProperty("Rank"); }
            set { if (Craft != value) { m_character.Modules.GetSkillModule("Craft").SetProperty("Rank", value); OnPropertyChanged("Craft"); } }
        }
        public int Diplomacy
        {
            get { return (int)m_character.Modules.GetSkillModule("Diplomacy").GetProperty("Rank"); }
            set { if (Diplomacy != value) { m_character.Modules.GetSkillModule("Diplomacy").SetProperty("Rank", value); OnPropertyChanged("Diplomacy"); } }
        }
        public int DisableDevice
        {
            get { return (int)m_character.Modules.GetSkillModule("Disable Device").GetProperty("Rank"); }
            set { if (DisableDevice != value) { m_character.Modules.GetSkillModule("Disable Device").SetProperty("Rank", value); OnPropertyChanged("Disable Device"); } }
        }
        public int Disguise
        {
            get { return (int)m_character.Modules.GetSkillModule("Disguise").GetProperty("Rank"); }
            set { if (Disguise != value) { m_character.Modules.GetSkillModule("Disguise").SetProperty("Rank", value); OnPropertyChanged("Disguise"); } }
        }
        public int EscapeArtist
        {
            get { return (int)m_character.Modules.GetSkillModule("Escape Artist").GetProperty("Rank"); }
            set { if (EscapeArtist != value) { m_character.Modules.GetSkillModule("Escape Artist").SetProperty("Rank", value); OnPropertyChanged("Escape Artist"); } }
        }
        public int Fly
        {
            get { return (int)m_character.Modules.GetSkillModule("Fly").GetProperty("Rank"); }
            set { if (Fly != value) { m_character.Modules.GetSkillModule("Fly").SetProperty("Rank", value); OnPropertyChanged("Fly"); } }
        }
        public int HandleAnimal
        {
            get { return (int)m_character.Modules.GetSkillModule("Handle Animal").GetProperty("Rank"); }
            set { if (HandleAnimal != value) { m_character.Modules.GetSkillModule("Handle Animal").SetProperty("Rank", value); OnPropertyChanged("Handle Animal"); } }
        }
        public int Heal
        {
            get { return (int)m_character.Modules.GetSkillModule("Heal").GetProperty("Rank"); }
            set { if (Heal != value) { m_character.Modules.GetSkillModule("Heal").SetProperty("Rank", value); OnPropertyChanged("Heal"); } }
        }
        public int Intimidate
        {
            get { return (int)m_character.Modules.GetSkillModule("Intimidate").GetProperty("Rank"); }
            set { if (Intimidate != value) { m_character.Modules.GetSkillModule("Intimidate").SetProperty("Rank", value); OnPropertyChanged("Intimidate"); } }
        }
        public int KnowledgeArcana
        {
            get { return (int)m_character.Modules.GetSkillModule("Knowledge (Arcana)").GetProperty("Rank"); }
            set { if (KnowledgeArcana != value) { m_character.Modules.GetSkillModule("Knowledge (Arcana)").SetProperty("Rank", value); OnPropertyChanged("Knowledge (Arcana)"); } }
        }
        public int KnowledgeDungeoneering
        {
            get { return (int)m_character.Modules.GetSkillModule("Knowledge (Dungeoneering)").GetProperty("Rank"); }
            set { if (KnowledgeDungeoneering != value) { m_character.Modules.GetSkillModule("Knowledge (Dungeoneering)").SetProperty("Rank", value); OnPropertyChanged("Knowledge (Dungeoneering)"); } }
        }
        public int KnowledgeEngineering
        {
            get { return (int)m_character.Modules.GetSkillModule("Knowledge (Engineering)").GetProperty("Rank"); }
            set { if (KnowledgeEngineering != value) { m_character.Modules.GetSkillModule("Knowledge (Engineering)").SetProperty("Rank", value); OnPropertyChanged("Knowledge (Engineering)"); } }
        }
        public int KnowledgeGeography
        {
            get { return (int)m_character.Modules.GetSkillModule("Knowledge (Geography)").GetProperty("Rank"); }
            set { if (KnowledgeGeography != value) { m_character.Modules.GetSkillModule("Knowledge (Geography)").SetProperty("Rank", value); OnPropertyChanged("Knowledge (Geography)"); } }
        }
        public int KnowledgeHistory
        {
            get { return (int)m_character.Modules.GetSkillModule("Knowledge (History)").GetProperty("Rank"); }
            set { if (KnowledgeHistory != value) { m_character.Modules.GetSkillModule("Knowledge (History)").SetProperty("Rank", value); OnPropertyChanged("Knowledge (History)"); } }
        }
        public int KnowledgeLocal
        {
            get { return (int)m_character.Modules.GetSkillModule("Knowledge (Local)").GetProperty("Rank"); }
            set { if (KnowledgeLocal != value) { m_character.Modules.GetSkillModule("Knowledge (Local)").SetProperty("Rank", value); OnPropertyChanged("Knowledge (Local)"); } }
        }
        public int KnowledgeNature
        {
            get { return (int)m_character.Modules.GetSkillModule("Knowledge (Nature)").GetProperty("Rank"); }
            set { if (KnowledgeNature != value) { m_character.Modules.GetSkillModule("Knowledge (Nature)").SetProperty("Rank", value); OnPropertyChanged("Knowledge (Nature)"); } }
        }
        public int KnowledgeNobility
        {
            get { return (int)m_character.Modules.GetSkillModule("Knowledge (Nobility)").GetProperty("Rank"); }
            set { if (KnowledgeNobility != value) { m_character.Modules.GetSkillModule("Knowledge (Nobility)").SetProperty("Rank", value); OnPropertyChanged("Knowledge (Nobility)"); } }
        }
        public int KnowledgePlanes
        {
            get { return (int)m_character.Modules.GetSkillModule("Knowledge (Planes)").GetProperty("Rank"); }
            set { if (KnowledgePlanes != value) { m_character.Modules.GetSkillModule("Knowledge (Planes)").SetProperty("Rank", value); OnPropertyChanged("Knowledge (Planes)"); } }
        }
        public int KnowledgeReligion
        {
            get { return (int)m_character.Modules.GetSkillModule("Knowledge (Religion)").GetProperty("Rank"); }
            set { if (KnowledgeReligion != value) { m_character.Modules.GetSkillModule("Knowledge (Religion)").SetProperty("Rank", value); OnPropertyChanged("Knowledge (Religion)"); } }
        }
        public int Linguistics
        {
            get { return (int)m_character.Modules.GetSkillModule("Linguistics").GetProperty("Rank"); }
            set { if (Linguistics != value) { m_character.Modules.GetSkillModule("Linguistics").SetProperty("Rank", value); OnPropertyChanged("Linguistics"); } }
        }
        public int Perception
        {
            get { return (int)m_character.Modules.GetSkillModule("Perception").GetProperty("Rank"); }
            set { if (Perception != value) { m_character.Modules.GetSkillModule("Perception").SetProperty("Rank", value); OnPropertyChanged("Perception"); } }
        }
        public int Perform
        {
            get { return (int)m_character.Modules.GetSkillModule("Perform").GetProperty("Rank"); }
            set { if (Perform != value) { m_character.Modules.GetSkillModule("Perform").SetProperty("Rank", value); OnPropertyChanged("Perform"); } }
        }
        public int Profession
        {
            get { return (int)m_character.Modules.GetSkillModule("Profession").GetProperty("Rank"); }
            set { if (Profession != value) { m_character.Modules.GetSkillModule("Profession").SetProperty("Rank", value); OnPropertyChanged("Profession"); } }
        }
        public int Ride
        {
            get { return (int)m_character.Modules.GetSkillModule("Ride").GetProperty("Rank"); }
            set { if (Ride != value) { m_character.Modules.GetSkillModule("Ride").SetProperty("Rank", value); OnPropertyChanged("Ride"); } }
        }
        public int SenseMotive
        {
            get { return (int)m_character.Modules.GetSkillModule("Sense Motive").GetProperty("Rank"); }
            set { if (SenseMotive != value) { m_character.Modules.GetSkillModule("Sense Motive").SetProperty("Rank", value); OnPropertyChanged("SenseMotive"); } }
        }
        public int SleightOfHand
        {
            get { return (int)m_character.Modules.GetSkillModule("Sleight of Hand").GetProperty("Rank"); }
            set { if (SleightOfHand != value) { m_character.Modules.GetSkillModule("Sleight Of Hand").SetProperty("Rank", value); OnPropertyChanged("Sleight Of Hand"); } }
        }
        public int Spellcraft
        {
            get { return (int)m_character.Modules.GetSkillModule("Spellcraft").GetProperty("Rank"); }
            set { if (Spellcraft != value) { m_character.Modules.GetSkillModule("Spellcraft").SetProperty("Rank", value); OnPropertyChanged("Spellcraft"); } }
        }
        public int Stealth
        {
            get { return (int)m_character.Modules.GetSkillModule("Stealth").GetProperty("Rank"); }
            set { if (Stealth != value) { m_character.Modules.GetSkillModule("Stealth").SetProperty("Rank", value); OnPropertyChanged("Stealth"); } }
        }
        public int Survival
        {
            get { return (int)m_character.Modules.GetSkillModule("Survival").GetProperty("Rank"); }
            set { if (Survival != value) { m_character.Modules.GetSkillModule("Survival").SetProperty("Rank", value); OnPropertyChanged("Survival"); } }
        }
        public int Swim
        {
            get { return (int)m_character.Modules.GetSkillModule("Swim").GetProperty("Rank"); }
            set { if (Swim != value) { m_character.Modules.GetSkillModule("Swim").SetProperty("Rank", value); OnPropertyChanged("Swim"); } }
        }
        public int UseMagicDevice
        {
            get { return (int)m_character.Modules.GetSkillModule("Use Magic Device").GetProperty("Rank"); }
            set { if (UseMagicDevice != value) { m_character.Modules.GetSkillModule("Use Magic Device").SetProperty("Rank", value); OnPropertyChanged("Use Magic Device"); } }
        }

        //  FEATS
        public class Feat
        {
            public Feat(IModule module)
            {
                m_feat = module;
            }
            IModule m_feat;
            public string FeatName
            {
                get { return (string)m_feat.GetProperty("Feat");}
                set { m_feat.SetProperty("Feat", value);}
            }
            public string Qualifier
            {
                get { return (string)m_feat.GetProperty("Qualifier"); }
                set { m_feat.SetProperty("Qualifier", value); }
            }
        }
        public ObservableCollection<Feat> FeatList
        {
            get 
            {
                ObservableCollection<Feat> result = new ObservableCollection<Feat>();
                foreach (IModule module in m_character.Modules.Feats)
                    result.Add(new Feat(module));
                return result;
            }
            set {  }
        }

        //  Current Textbox Text
        public string currentFeatName { get; set; }
        public string currentQualifier { get; set; }

        //  Add Feat Command
        public ICommand AddFeatCommand
        {
            get
            {
                if (c_addFeatCommand == null)
                {
                    c_addFeatCommand = new CommandInterface(
                        param => this.AddFeat(),
                        param => this.CanAddFeat());
                }
                return c_addFeatCommand;
            }
        }
        public void AddFeat()
        {
            IModule feat = ModuleFactory.CreateModule("FeatModule", currentFeatName);
            feat.SetProperty("Qualifier", currentQualifier);
            m_character.Modules.AddModule(feat);
            OnPropertyChanged("FeatList");
        }
        public bool CanAddFeat()
        {
            return !IsStringMissing(currentFeatName);
        }

        //  Presentation Properties

        public override string DisplayName
        {
            get
            {
                if (cvm.IsNewCharacter)
                {
                    return "~CORE STATS~\n" + Resources.TabLabel_NewCharacter;
                }
                else
                {
                    if (m_propertyChanged)
                        return "~CORE STATS~\n" + cvm.Name + "*";
                    else
                        return "~CORE STATS~\n" + cvm.Name;
                }
            }
        }


        /// <summary>
        /// Returns a command that saves the Character.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                if (c_saveCommand == null)
                {
                    c_saveCommand = new CommandInterface(
                        param => this.Save(),
                        param => this.CanSave
                        );
                }
                return c_saveCommand;
            }
        }

        //  Public Methods

        /// <summary>
        /// Saves the Character to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        public void Save()
        {
            if (!m_character.IsValid())
                throw new InvalidOperationException(Resources.NewCharacter_Exception_CannotSave);

            if (m_propertyChanged)
            {
                if (!cvm.IsNewCharacter)
                    cvm.DeleteCharacter();

                cvm.Character = m_character;
                cvm.SaveCharacter();
                this.CloseCommand.Execute(null);

                m_propertyChanged = false;
                base.OnPropertyChanged("DisplayName");
            }
        }

        //  Private Helpers



        /// <summary>
        /// Returns true if the Character is valid and can be saved.
        /// </summary>
        bool CanSave
        {
            get { return m_character.IsValid(); }
        }

        //  IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return (m_character as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;

                switch (propertyName)
                {
                    case "Name":
                        error = this.ValidateName();
                        break;

                    case "Race":
                        error = this.ValidateRace();
                        break;

                    case "Class":
                        error = this.ValidateClass();
                        break;

                    default:
                        error = (m_character as IDataErrorInfo)[propertyName];
                        break;
                }

                // Dirty the commands registered with CommandManager,
                // such as our Save command, so that they are queried
                // to see if they can execute now.
                CommandManager.InvalidateRequerySuggested();

                return error;
            }
        }

        string ValidateName()
        {
            if (IsStringMissing(this.Name))
            {
                return Resources.NewCharacter_Error_NoName;
            }
            return null;
        }

        string ValidateRace()
        {

            if (IsStringMissing(this.Race))
                return Resources.NewCharacter_Error_NoRace;

            return null;
        }
        string ValidateClass()
        {
            if (IsStringMissing(this.Class))
                return Resources.NewCharacter_Error_NoClass;

            return null;
        }
 
        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }
    }
}