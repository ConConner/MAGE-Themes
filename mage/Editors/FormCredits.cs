using mage.Data;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Editors;

public partial class FormCredits : Form
{
    static class CreditsEntryColumns
    {
        public const string Type = nameof(CreditsEntry.Type);
        public const string Text = nameof(CreditsEntry.Text);
    }

    Status Status;
    Credits LoadedCredits;

    DataGridViewComboBoxColumn colType;
    DataGridViewTextBoxColumn colText;

    public FormCredits()
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        LoadedCredits = new(ROM.Stream, Version.CreditsOffset);
        InitializeColumns();
        dataGrid_credits.CellValidating += DataGrid_credits_CellValidating;

        Status = new(statusLabel_changes, button_apply);
    }

    private void InitializeColumns()
    {
        dataGrid_credits.AutoGenerateColumns = false;

        colType = new DataGridViewComboBoxColumn()
        {
            DataPropertyName = CreditsEntryColumns.Type,
            HeaderText = "Line Type",
            ValueType = typeof(CreditsEntryType),
            DataSource = Enum.GetValues<CreditsEntryType>(),
            ValueMember = null,
            DisplayMember = null,
            Resizable = DataGridViewTriState.False,
            Width = 110,
            Name = "colType"
        };

        colText = new DataGridViewTextBoxColumn()
        {
            DataPropertyName = CreditsEntryColumns.Text,
            HeaderText = "Line Text",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            Name = "colText",
        };
        if (!Version.IsMF)
            colText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        dataGrid_credits.Columns.AddRange(colType, colText);
        dataGrid_credits.DataSource = LoadedCredits.Entries;
    }

    /// <summary>
    /// Prompts the user if they want to save the current changes or cancel.
    /// </summary>
    /// <returns>False if cancelled. True for other options. Saves if yes is clicked</returns>
    private bool CheckUnsaved()
    {
        DialogResult result = MessageBox.Show("Do you want to save changes to the Credits?",
            "Unsaved Changes", MessageBoxButtons.YesNoCancel);
        if (result == DialogResult.Cancel) return false;
        if (result == DialogResult.Yes) Save();
        return true;
    }

    private void Save()
    {

    }

    private void dataGrid_credits_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        e.ThrowException = false;
        MessageBox.Show("A line of Text must not have more than 35 characters on it.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void DataGrid_credits_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex != colText.Index) return;

        string txt = e.FormattedValue?.ToString() ?? "";
        if (txt.Length > 35)
        {
            dataGrid_credits.Rows[e.RowIndex].ErrorText = "Max 35 chars";
            e.Cancel = true;
            MessageBox.Show("A line of Text must not have more than 35 characters on it.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        dataGrid_credits.Rows[e.RowIndex].ErrorText = "";
    }

    private void dataGrid_credits_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) Status.ChangeMade();
    }

    private void FormCredits_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (Status.UnsavedChanges && !CheckUnsaved())
        {
            e.Cancel = true;
            return;
        }
    }
}
