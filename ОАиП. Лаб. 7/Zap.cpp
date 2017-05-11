//---------------------------------------------------------------------------
#pragma hdrstop
#include "conio.h"
#include "Zap.h"

Zap::Zap() {
	isFull = false;
	next = NULL;
}

Zap::Zap(int _key, int _info) {
	key = _key;
	info = _info;
	next = NULL;
	isFull = true;
}

Zap::Key() {
	return key;
}

Zap::Info() {
	return info;
}



#pragma package(smart_init)
