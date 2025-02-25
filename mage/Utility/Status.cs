using System;
using System.Windows.Forms;

namespace mage
{
    public class Status
    {
        public bool UnsavedChanges { get; private set; }
        private ToolStripStatusLabel statusLabel;
        private Button applyButton;
        private ToolStripDropDownButton altApplyButton;

        public Status(ToolStripStatusLabel statusLabel, Button applyButton = null)
        {
            this.statusLabel = statusLabel;
            this.applyButton = applyButton;
            UnsavedChanges = false;
        }
        public Status(ToolStripStatusLabel statusLabel, ToolStripDropDownButton applyButton) : this(statusLabel)
        {
            this.altApplyButton = applyButton;
        }

        public void ChangeMade()
        {
            if (!UnsavedChanges)
            {
                UnsavedChanges = true;
                statusLabel.Text = "Unsaved changes";
                ToggleApplyButton(true);
            }
        }

        public void LoadNew()
        {
            if (UnsavedChanges)
            {
                UnsavedChanges = false;
                statusLabel.Text = "Changes discarded";
                ToggleApplyButton(false);
            }
            else
            {
                statusLabel.Text = "";
            }
        }

        public void Save()
        {
            if (UnsavedChanges)
            {
                UnsavedChanges = false;
                statusLabel.Text = "Changes saved";
                ToggleApplyButton(false);
            }
            else
            {
                statusLabel.Text = "No changes to save";
            }
        }

        public void Import()
        {
            UnsavedChanges = false;
            statusLabel.Text = "Changes saved";
            ToggleApplyButton(false);
        }

        private void ToggleApplyButton(bool enable)
        {
            if (applyButton != null)
            {
                applyButton.Enabled = enable;
            }
            if (altApplyButton != null)
            {
                altApplyButton.Enabled = enable;
            }
        }


    }
}
