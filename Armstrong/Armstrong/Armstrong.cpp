#include <iostream>
#include <Windows.h>
#include <cstdlib>

extern "C" int asm_func(int first_number, int last_number);

int main(int argc, char** argv)
{
    std::cout << "You have entered " << argc << " arguments:" << "\n";

    for (int i = 0; i < argc; i++)
        std::cout << argv[i] << "\n";

    int first_number = std::atoi(argv[1]);
    int last_number = std::atoi(argv[2]);

    int result = asm_func(first_number, last_number);

    std::cout <<"Sum of arguments is asm: " <<  result;
    return 0;
}

