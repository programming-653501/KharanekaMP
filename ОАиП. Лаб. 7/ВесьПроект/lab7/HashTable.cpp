//---------------------------------------------------------------------------


#pragma hdrstop
#include "HashTable.h"

Table::Table() {
	hashTable = new Zap[10];
}

int Table::HashCode(int key) {
	return key%10;
}
// Добавление данных в соответствующую ячейку таблицы.
void Table::Add(Zap* data) {
	int hCode = HashCode(data->Key());
	if(!hashTable[hCode].isFull) {
		hashTable[hCode] = *data;
		hashTable[hCode].isFull = true;
	}
	else {                                 // Если ячейка занята,
		Zap* ceil = &hashTable[hCode];     // данные добавляются в конец
		while(ceil->next != NULL) {        // однонаправленного списка.
			ceil = ceil->next;
		}
		ceil->next = data;
	}
}
// Поиск элемента по ключу.
Zap* Table::Find(int key) {
	int hCode = HashCode(key);
	if(!hashTable[hCode].isFull){
		return NULL;
	}
	else {
		Zap* ceil = hashTable + hCode;
		while (ceil->next != NULL) {
			ceil = ceil->next;
		}
		return ceil;
	}
}
// Копирование ключей таблицы в массив строк.
UnicodeString* Table::ToPrint() {
	UnicodeString* strings = new UnicodeString[10];
	for(int i = 0; i < 10; i++) {
		strings[i] = "";
		if(!hashTable[i].isFull) {
			continue;
		}
		else {
			Zap* ceil = hashTable + i;
			strings[i] += IntToStr(ceil->Key());
			while (ceil->next != NULL) {
				ceil = ceil->next;
				strings[i] += "   ";
				strings[i] += IntToStr(ceil->Key());
			}
		}
	}
	return strings;
}
// Деление таблицы на две: с ключами больше num и меньше.
void Table::Cut(Table* &hashTableLess, Table* &hashTableMore, int num) {
	for(int i = 0; i < 10; i++) {
		if(!hashTable[i].isFull) {
			continue;
		} else {
			Zap* ceil = hashTable + i;
			Zap* ceilCopy = new Zap(ceil->Key(), ceil->Info());
			ceilCopy->Key() < num ? hashTableLess->Add(ceilCopy) :
				hashTableMore->Add(ceilCopy);
			while (ceil->next != NULL) {
				ceil = ceil->next;
				ceilCopy = new Zap(ceil->Key(), ceil->Info());
				ceil->Key() < num ? hashTableLess->Add(ceilCopy) :
					 hashTableMore->Add(ceilCopy);
			}
		}
	}
}


#pragma package(smart_init)



