//---------------------------------------------------------------------------

#ifndef _LAB7_MAIN_H_
#define _LAB7_MAIN_H_
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TMemo *FullHashTable;
	TButton *GenerateTable;
	TEdit *CuttingNumber;
	TMemo *HashTableLess;
	TMemo *HashTableMore;
	TButton *Cut;
	void __fastcall GenerateTableClick(TObject *Sender);
	void __fastcall CutClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
