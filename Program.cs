using System;
using System.Windows.Forms;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}

/*
use DeuserAppConsoleDB

// Eliminar todos los documentos en la colección DeletedIds
db.DeletedIds.deleteMany({})

// Restablecer el contador en la colección Counters
db.Counters.updateOne(
  { _id: "userId" },
  { $set: { sequenceValue: 0 } }
)
*/