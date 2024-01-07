#include <iostream>
#include <cstdlib>
#include <sstream>
#include <vector>
#include <thread>

extern "C" int asm_power(int first_number, int last_number);

int power(int x, int y) {
	//we don't want to import whole math.c for just integer power.
	int result = 1;
	for (int i{ 0 }; i < y; ++i) result *= x;
	return result;
}

std::vector<int> splitNumber(int number) {
	std::vector<int> result;
	while (number >= 1) {
		result.push_back((int)(number - 10 * (number / 10)));
		number /= 10;
	}
	return result;
}

int getSumOfNumberDigitsPower(std::vector<int> numbers, int exponent) {
	int sum = 0;
	for (auto i : numbers) {
		//sum += asm_power(i, exponent);
		sum += power(i, exponent);
	}
	return sum;
}

void printArmstrongTestResultMessage(bool succeeded, int number, int exponent) {
	std::vector<int> digits = splitNumber(number);
	if (succeeded) {
		for (auto i : digits) {
			std::cout << i << "^" << exponent << " + ";
		}
		std::cout << "\033[2D= " << number << std::endl;
		std::cout << "This is Armstrong's number for the power of " << exponent << "." << std::endl;
		return;
	}
	//std::cout << "\nThis is not an Armstrong's number";
}

/* This function only tests number and prints out result to screen */
void armstrongTest(int number) {
	std::vector<int> digits = splitNumber(number);
	int exponent = digits.size();
	int sum = getSumOfNumberDigitsPower(digits, exponent);
	printArmstrongTestResultMessage(sum == number, number, exponent);
}

/* Overloaded Armstrong's test with customizable exponent */
void armstrongTest(int number, int exponent) {
	std::vector<int> digits = splitNumber(number);
	int sum = getSumOfNumberDigitsPower(digits, exponent);
	printArmstrongTestResultMessage(sum == number, number, exponent);
}

void armstrongRange(int numMin, int numMax, int exponentMin, int exponentMax) {
	for (int r = exponentMin; r <= exponentMax; ++r) {
		for (int n = numMin; n <= numMax; ++n) {
			armstrongTest(n, r);
		}
	}
}

int parseArgToInt(const char* arg) {
	int result;
	std::istringstream ss{ arg };
	ss >> result;
	return result;
}

int main(int argc, char* argv[]) {
	/*std::cout << "Arguments: " << argc - 1;
	for (int i = 1; i < argc; i++) {
		std::cout << "\nArg " << i << ": " << argv[i];
	}*/
	if (argc < 2) {
		//user provided no arguments - print usage info
		std::cout << "\nUsage:\n./armstrong number\t\t\ttest if number with n digits equals sum of digits each to power of n\n./Armstrong number ex";
		std::cout << "ponent\t\ttest if Armstrong's number for power of 'exponent'\n./armstrong number1 number2 exponent\t\tsearch all Armstrong ";
		std::cout << "numbers in range <number1,number2> for power of 'exponent'\n./armstrong num1 num2 exponent1 exponent2\t\tsearch all Armstro";
		std::cout << "ng numbers in range <num1,num2> for all powers from 'exponent1' to 'exponent2' including.\nPlease consider time it can ";
		std::cout << "take if ranges are too wide\nAuthors:\n\tKrystian Gagracz\n\tPiotr Kluziok\n\tPawel Mielimonka\n\n";
	}
	else if (argc == 2) {
		//1 argmuent: number to test.
		armstrongTest(parseArgToInt(argv[1]));
	}
	else if (argc == 3) {
		//2 arguments: {number, exponent}
		armstrongTest(parseArgToInt(argv[1]), parseArgToInt(argv[2]));
	}
	else if (argc == 4) {
		//3 arguments: {numMin, numMax, exponent}
		//faster loop when end condition doesn't call a function every time. the same for exponent.
		//int nmax = parseArgToInt(argv[2]);
		//int exponent = parseArgToInt(argv[3]);
		//for (int n = parseArgToInt(argv[1]); n <= nmax; ++n) armstrongTest(n, exponent);
		std::thread t(armstrongRange, parseArgToInt(argv[1]), parseArgToInt(argv[2]), parseArgToInt(argv[3]), parseArgToInt(argv[3]));
		t.join();
	}
	else if (argc > 4) {
		//4 arguments: {1: numMin, 2: numMax, 3: exponentMin, 4: exponentMax}
		//faster loop when end condition doesn't call a function every time.
		//std::thread t(armstrongRange, parseArgToInt(argv[1]), parseArgToInt(argv[2]), parseArgToInt(argv[3]), parseArgToInt(argv[4]));
		//t.join();
		int minTestedNumber = parseArgToInt(argv[1]);
		int maxTestedNumber = parseArgToInt(argv[2]);
		int minExponent = parseArgToInt(argv[3]);
		int maxExponent = parseArgToInt(argv[4]);
		for (int r = minExponent; r <= maxExponent; ++r)
			for (int n = minTestedNumber; n <= maxTestedNumber; ++n)
				armstrongTest(n, r);
	}

}
