// Файл содержит класс хеш-таблицы.
#ifndef _LAB7_HASHTABLE_H_
#define _LAB7_HASHTABLE_H_

#include "vcl.h"
#include "Zap.h"

class Table {
private:
	Zap* hashTable;

public:
	Table();
	UnicodeString* ToPrint();
	void Cut(Table*&, Table*&, int);
	static int HashCode(int);
	void Add(Zap*);
	Zap* Find(int);

};

#endif
