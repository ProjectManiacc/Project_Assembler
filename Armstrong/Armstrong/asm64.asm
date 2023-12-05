
.code
ALIGN 16

asm_func PROC arg1:DWORD, arg2:DWORD
	
	mov eax, ecx
	add eax, edx

	ret
asm_func ENDP

END
