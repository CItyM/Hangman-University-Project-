using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hangman.Database;

namespace Hangman
{
    public partial class AddContentForm : Form
    {
        private List<string> mWords;
        private List<string> mCategoriesNames;

        private long mCategID = 0;
        private string mCategName;

        private CRUDOperations mCRUD;

        public enum Type
        {
            Word = 0,
            Category = 1
        }

        public AddContentForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            mCRUD = new CRUDOperations();
            lblWords.Visible = false;
            cbWords.Visible = false;

            LoadCbCateg();
            txtEdit.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                Application.OpenForms[i].Enabled = true;
                Application.OpenForms[i].Focus();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((Type)cbType.SelectedIndex == Type.Word)
            {
                AddWordToDB();
            }

            if ((Type)cbType.SelectedIndex == Type.Category)
            {
                AddCategToDB();
                LoadCbCateg();
            }
            txtEdit.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((Type)cbType.SelectedIndex == Type.Word)
            {
                DeleteWordFromDB();
            }
            if ((Type)cbType.SelectedIndex == Type.Category)
            {
                DeleteCategoryFromDB();
            }
            txtEdit.Clear();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEdit.Clear();
            cbCateg.Text = null;

            if ((Type)cbType.SelectedIndex == Type.Category)
            {
                lblWords.Visible = false;
                cbWords.Visible = false;
            }
        }

        private void cbCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mCategName = cbCateg.SelectedItem.ToString();
                mCategID = mCRUD.GetCategoryIDs(mCategName);

                if ((Type)cbType.SelectedIndex == Type.Word)
                {
                    lblWords.Visible = true;
                    cbWords.Visible = true;
                    LoadCbWords();
                    txtEdit.Text = string.Empty;
                }
                if ((Type)cbType.SelectedIndex == Type.Category)
                {
                    txtEdit.Text = cbCateg.SelectedItem.ToString();
                }
            }
            catch { }
        }

        private void cbWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEdit.Text = cbWords.SelectedItem.ToString();
        }

        private void AddWordToDB()
        {
            if ((Type)cbType.SelectedIndex == Type.Word)
            {
                try
                {
                    if (cbCateg.SelectedIndex > -1)
                    {
                        using (var db = new HangmanDB())
                        {
                            var word = new Word
                            {
                                WordName = txtEdit.Text,
                                CategoryID = mCategID
                            };

                            db.Words.Add(word);
                            db.SaveChangesAsync();
                            LoadCbWords();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Изберете Категория");
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        private void DeleteWordFromDB()
        {
            if ((Type)cbType.SelectedIndex == Type.Word)
            {
                try
                {
                    if (cbCateg.SelectedIndex > -1)
                    {
                        using (var db = new HangmanDB())
                        {
                            var word = db.Words.Where(w => (w.WordName == cbWords.SelectedItem.ToString() && w.CategoryID == mCategID)).Select(w => w).ToList();
                            db.Words.Remove(word[0]);
                            db.SaveChangesAsync();
                            LoadCbWords();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Изберете Категория");
                    }
                }
                catch
                {
                    MessageBox.Show("Изберете дума");
                }
            }
        }

        private void DeleteCategoryFromDB()
        {
            if ((Type)cbType.SelectedIndex == Type.Category)
            {
                try
                {
                    if (cbCateg.SelectedIndex > -1)
                    {
                        using (var db = new HangmanDB())
                        {
                            var categ = db.Categories.Where(c => (c.CategoryName == cbCateg.SelectedItem.ToString())).Select(c => c).ToList();
                            var words = db.Words.Where(w => w.CategoryID == mCategID).Select(w => w).ToList();

                            foreach (var word in words)
                            {
                                db.Words.Remove(word);
                            }
                            db.Categories.Remove(categ[0]);



                            db.SaveChangesAsync();
                            LoadCbCateg();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Изберете Категория");
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        private void AddCategToDB()
        {
            if ((Type)cbType.SelectedIndex == Type.Category)
            {
                try
                {

                    using (var db = new HangmanDB())
                    {
                        var categ = new Category
                        {
                            CategoryName = txtEdit.Text
                        };

                        db.Categories.Add(categ);
                        db.SaveChangesAsync();
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        private void LoadCbCateg()
        {
            mCategoriesNames = mCRUD.GetCategoryNames();
            cbCateg.Items.Clear();
            foreach (var category in mCategoriesNames)
            {
                cbCateg.Items.Add(category);
            }
        }

        private void LoadCbWords()
        {
            mWords = mCRUD.GetWordsNameByCategory(mCategID);
            cbWords.Items.Clear();
            foreach (var word in mWords)
            {
                cbWords.Items.Add(word);
            }
        }


    }
}
