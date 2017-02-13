using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data.Entity;

namespace Hangman
{
    public partial class MainForm : Form
    {
        private List<string> mLethers;
        private List<ModLabel> mLabels;
        private List<Label> mWordLabels;

        private string mCategName;
        private string mRandomWord = "";
        private long mCategID;
        private int mLeatherLblStartX = 455;
        private int mLeatherLblStartY = 75;
        private int mExpIndex = 55;
        private int mLthNunber = 0;
        private int mMistakesCount = 0;
        private int mWordLenght = 2;
        private int mCbChangeCount = 0;
        private int mWinCount = 0;
        private int mLoseCount = 0;
        private bool mIsExists = false;

        private ModLabel mLabel;
        private CRUDOperations mCRUD;

        public MainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            mCRUD = new CRUDOperations();
            mLethers = WordHelper.LoadLeathers();
            mWordLabels = new List<Label>();
            mLabels = new List<ModLabel>();

            SetPicsInvisible();
            picStart.Visible = true;
            SetUpLeathersLabels();
            LoadCbCateg();

            EnabledChanged += (sender, e) =>
            {
                LoadCbCateg();
            };

            picSevenMis.Click += (sender, e) =>
            {
                SetPicsInvisible();
                picStart.Visible = true;
                SetUpLeathersLabels();
                for (int i = 0; i < mWordLabels.Count; i++)
                {
                    Controls.Remove(mWordLabels[i]);
                }
            };
        }

        private void LabelClicked(object sender, LabelEventArgs e)
        {
            try
            {
                var lbl = sender as Label;
                if (cbCateg.SelectedItem != null)
                {
                    lbl.ForeColor = Color.Red;

                    CheckIfLeatherExists(e.Text);
                }

            }
            catch
            {
                MessageBox.Show("Моля първо изберете категория.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddContentForm();
            form.Show();
            this.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Сигурни ли сте, че искате да излезете?", "Изход", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cbCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            mCategName = cbCateg.SelectedItem.ToString();
            mCategID = mCRUD.GetCategoryIDs(mCategName);
            try
            {
                if (mCbChangeCount == 0)
                {
                    mRandomWord = mCRUD.GetRandomWord(mCategID);
                    SetUpWordLabels();
                    mCbChangeCount++;
                }
                else
                {
                    mRandomWord = mCRUD.GetRandomWord(mCategID);
                    SetUpLeathersLabels();
                    SetPicsInvisible();
                    picStart.Visible = true;
                    mMistakesCount = 0;
                    mWordLenght = 2;
                    SetUpWordLabels();
                }

            }
            catch
            {
                MessageBox.Show("Моля добавете думи първо.");

            }
        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
            LoadCbCateg();
        }

        private void CheckIfLeatherExists(string leather)
        {
            var leatherPositions = new List<int>();
            string word = WordHelper.NoFirstLast(mRandomWord);

            mIsExists = WordHelper.IsLeatherExists(word, leather, mIsExists, leatherPositions);

            if (mIsExists == true)
            {
                mWordLenght += leatherPositions.Count();
                mIsExists = false;
            }
            else
            {
                mMistakesCount++;
            }

            for (int i = 0; i < leatherPositions.Count; i++)
            {
                mWordLabels[leatherPositions[i] + 1].Text = leather;
            }

            if (mWordLenght == mRandomWord.Length)
            {
                EndGame();
            }

            switch (mMistakesCount)
            {
                case 0: break;
                case 1:
                    SetPicsInvisible();
                    picOneMis.Visible = true;
                    break;
                case 2:
                    SetPicsInvisible();
                    picTwoMis.Visible = true;
                    break;
                case 3:
                    SetPicsInvisible();
                    picThreeMis.Visible = true;
                    break;
                case 4:
                    SetPicsInvisible();
                    picFourMis.Visible = true;
                    break;
                case 5:
                    SetPicsInvisible();
                    picFiveMis.Visible = true;
                    break;
                case 6:
                    SetPicsInvisible();
                    picSixMis.Visible = true;
                    break;
                case 7:
                    SetPicsInvisible();
                    picSevenMis.Visible = true;
                    picSevenMis.Enabled = true;
                    EndGame();
                    break;
            }
        }

        private void EndGame()
        {
            if (mMistakesCount == 7)
            {
                MessageBox.Show("Жалко. Следващия път!", "Загуба");
                SetUpWordLabels();
                DisableLabels();
                mLoseCount++;
                lblLose.Text = mLoseCount.ToString();
            }
            else
            {
                var res = MessageBox.Show("Браво! Вие, победихте.", "Победа", MessageBoxButtons.OK);
                SetPicsInvisible();
                picStart.Visible = true;
                SetUpLeathersLabels();
                SetUpWordLabels();
                mWordLenght = 2;
                mWinCount++;
                lblWin.Text = mWinCount.ToString();
                if (DialogResult.OK == res)
                {
                    for (int i = 0; i < mWordLabels.Count; i++)
                    {
                        Controls.Remove(mWordLabels[i]);
                    }
                }

            }

            mMistakesCount = 0;
            mWordLenght = 0;
        }

        private void SetPicsInvisible()
        {
            picStart.Visible = false;
            picOneMis.Visible = false;
            picTwoMis.Visible = false;
            picThreeMis.Visible = false;
            picFourMis.Visible = false;
            picFiveMis.Visible = false;
            picSixMis.Visible = false;
            picSevenMis.Visible = false;
            picSevenMis.Enabled = false;
        }    

        private void SetUpLeathersLabels()
        {
            for (int i = 0; i < mLabels.Count; i++)
            {
                Controls.Remove(mLabels[i]);
                Console.WriteLine("sdgasdhujk");
            }

            mLabels = new List<ModLabel>();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    var lbl = new ModLabel();
                    lbl.Name = "lblLeather" + (mLthNunber + 1);
                    lbl.Text = mLethers[mLthNunber];
                    lbl.Location = new Point(mLeatherLblStartX + (j * mExpIndex),
                                             mLeatherLblStartY + (i * mExpIndex));
                    lbl.Size = new Size(48, 39);
                    lbl.ForeColor = Color.Black;
                    lbl.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Underline | FontStyle.Bold);
                    this.Controls.Add(lbl);
                    mLabels.Add(lbl);
                    mLthNunber++;
                }
            }
            for (int i = 0; i < mLabels.Count; i++)
            {
                mLabel = mLabels[i];
                mLabel.GetText += LabelClicked;
            }

            mLthNunber = 0;
        }

        private void SetUpWordLabels()
        {
            for (int i = 0; i < mWordLabels.Count; i++)
            {
                Controls.Remove(mWordLabels[i]);
            }
            mWordLabels = new List<Label>();
            var index = mRandomWord.Count();
            var firstLeather = mRandomWord.First().ToString();
            var lastLeather = mRandomWord.Last().ToString();

            switch (mMistakesCount)
            {
                case 0:
                    for (int i = 0; i < index; i++)
                    {
                        var lbl = new Label();
                        lbl.Name = "lblWord" + (i + 1);
                        SetWordLabelText(lbl, i, index, firstLeather, lastLeather);
                        lbl.Location = new Point(240 + (i * 50), 395);
                        lbl.Size = new Size(50, 50);
                        lbl.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Underline | FontStyle.Bold);
                        this.Controls.Add(lbl);
                        mWordLabels.Add(lbl);
                    }

                    for (int i = 0; i < index; i++)
                    {
                        Controls.SetChildIndex(mWordLabels[i], 0);
                    }
                    break;
                case 7:
                    for (int i = 0; i < index; i++)
                    {
                        var lbl = new Label();
                        lbl.Name = "lblWord" + (i + 1);
                        lbl.Text = mRandomWord[i].ToString();
                        lbl.Location = new Point(240 + (i * 50), 395);
                        lbl.Size = new Size(50, 50);
                        lbl.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Underline | FontStyle.Bold);
                        this.Controls.Add(lbl);
                        mWordLabels.Add(lbl);
                    }

                    for (int i = 0; i < index; i++)
                    {
                        Controls.SetChildIndex(mWordLabels[i], 0);
                    }
                    break;
            }


        }

        private void SetWordLabelText(Label lbl, int i, int index, string first, string last)
        {
            if (i == 0)
            {
                lbl.Text = first;
            }
            else if (i == index - 1)
            {
                lbl.Text = last;
            }
            else
            {
                lbl.Text = "_";
            }
        }

        private void LoadCbCateg()
        {
            var categs = mCRUD.GetCategoryNames();
            cbCateg.Items.Clear();
            foreach (var categ in categs)
            {
                cbCateg.Items.Add(categ);
            }
        }

        private void DisableLabels()
        {
            foreach (var label in mLabels)
            {
                label.Enabled = false;
            }
        }

        public class LabelEventArgs : EventArgs
        {
            public string Text { get; set; }
        }

        public class ModLabel : Label
        {
            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                LabelEventArgs args = new LabelEventArgs();
                args.Text = this.Text;
                OnGetText(args);
            }

            protected virtual void OnGetText(LabelEventArgs e)
            {
                GetText?.Invoke(this, e);
            }

            public event EventHandler<LabelEventArgs> GetText;
        }
    }
}
