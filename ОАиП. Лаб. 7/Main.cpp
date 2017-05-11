//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Main.h"
#include "HashTable.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
Table* hashTable;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner) {
	hashTable = NULL;
}
//---------------------------------------------------------------------------
// ������� ��������� ������� ���������� �������.
void __fastcall TForm1::GenerateTableClick(TObject *Sender) {
	FullHashTable->Clear();
	hashTable = new Table;
	randomize();
	for (int i = 0; i < 20; i++) {
		hashTable->Add(new Zap(random(100), random(100)));
	}
	UnicodeString* tableStrings = hashTable->ToPrint();
	for(int i = 0; i < 10; i++) {
		FullHashTable->Lines->Add(tableStrings[i]);
	}
}
//---------------------------------------------------------------------------
// ������� ������� 2 �������, �������������� ��� ���������� ��������.
void __fastcall TForm1::CutClick(TObject *Sender) {
	HashTableLess->Clear();
	HashTableMore->Clear();
	int cutNum = 0;
	try {
		cutNum = CuttingNumber->Text.ToInt();
	}
	catch(Exception* e) {
		ShowMessage(e->Message);
		return;
	}
	Table* hashTableLess = new Table;
	Table* hashTableMore = new Table;
	if(hashTable != NULL) {
		hashTable->Cut(hashTableLess, hashTableMore, cutNum);
	}
	UnicodeString *TableStringsLess, *TableStringsMore;
	TableStringsLess = hashTableLess->ToPrint();
	TableStringsMore = hashTableMore->ToPrint();
	for(int i = 0; i < 10; i++) {
		HashTableLess->Lines->Add(TableStringsLess[i]);
		HashTableMore->Lines->Add(TableStringsMore[i]);
	}
}
//---------------------------------------------------------------------------

