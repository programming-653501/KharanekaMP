// ‘айл содержит класс, в котором описана €чейка таблицы.

#ifndef _LAB7_ZAP_H_
#define _LAB7_ZAP_H_

class Zap {
private:
	int key;
	int info;

public:
	Zap(int key, int info);
	Zap();
	int Key();
	int Info();
	Zap* next;
	bool isFull;
};

#endif
