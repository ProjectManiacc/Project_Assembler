#include <iostream>
#include <cstdlib>
#include <sstream>
#include <vector>

extern "C" int asm_func(int first_number, int last_number);

int power(int x, int y) {
	//we don't want to import whole math.c for just integer power.
	int result = 1;
	for (int i{0}; i < y; ++i) result*=x;
	return result;
}

std::vector<int> splitNumber(int number) {
	std::vector<int> result;
	while (number > 1) {
		result.push_back((int)(number - 10*(number/10)));
		number /= 10;
	}
	return result;
}

/* This function only tests number and prints out result to screen,
 * but only if number meets Armstrong's condition
 */
void armstrongTest(int number, int toPower) {
	std::vector<int> digits = splitNumber(number);
	int sum = 0;
	for (auto i : digits) {
		sum += power(i,toPower);
	}
	if (sum == number) {
		std::cout << "\nTested number: " << number << std::endl;
		for (auto i : digits) {
			std::cout << i << "^"<< toPower <<" + ";
		}
		std::cout << "\033[2D= " << sum << std::endl;
		std::cout << "This is Armstrong's number A"<< toPower <<"." << std::endl;
	}
}

int parseArgToInt(char* arg){
	int result;
	std::istringstream ss{arg};
	ss >> result;
	return result;
}

int main(int argc, char* argv[]) {
	if (argc < 2) {
		//user provided no arguments - print usage info
		std::cout << "\nUsage:\n./armstrong number\t\t\ttest if number equals sum of digits each to power of 3\n./Armstrong number ra";
		std::cout << "nk\t\ttest if Armstrong's number for power of 'rank'\n./armstrong number1 number2 rank\t\tsearch all Armstrong ";
		std::cout << "numbers in range <number1,number2> for power of 'rank'\n./armstrong num1 num2 rank1 rank2\t\tsearch all Armstro";
		std::cout << "ng numbers in range <num1,num2> for all powers from 'rank1' to 'rank2' including.\nPlease consider time it can ";
		std::cout << "take if ranges are too wide\nAuthors:\n\tKrystian Gagracz\n\tPiotr Kluziok\n\tPawel Mielimonka\n\n";
	} else if (argc == 2){
		//1 argmuent: number to test, rank = 3.
		armstrongTest(parseArgToInt(argv[1]), 3);
	} else if (argc == 3) {
		//2 arguments: {number, rank}
		armstrongTest(parseArgToInt(argv[1]), parseArgToInt(argv[2]));
	} else if (argc == 4) {
		//3 arguments: {numMin, numMax, rank}
		//faster loop when end condition doesn't call a function every time. the same for rank.
		int nmax = parseArgToInt(argv[1]);
		int rank = parseArgToInt(argv[2]);
		for (int n = parseArgToInt(argv[0]); n <= nmax; ++n) armstrongTest(n, rank);
	} else if (argc > 4) {
		//4 arguments: {numMin, numMax, rankMin, rankMax}
		//faster loop when end condition doesn't call a function every time.
		int rmax = parseArgToInt(argv[3]);
		int nmax = parseArgToInt(argv[1]);
		for (int r = parseArgToInt(argv[2]); r <= rmax; ++r)
			for (int n = parseArgToInt(argv[0]); n <= nmax; ++n)
				armstrongTest(n, r);
	}

}
