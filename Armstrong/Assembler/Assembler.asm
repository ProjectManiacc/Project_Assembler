.data

.code
asm_power PROC	
	movdqu xmm0, [rcx]		; load 4 ints from memory pointed by rcx ("input")
	movdqu xmm2, xmm0		; copy these ints to xmm2 ("result")
	cmp edx, 1			; compare exponent to 1
	jle power_end     		; if exponent <= 1, jump to end
	power_loop:
		pmulld xmm2, xmm0 	; multiply result by input
		dec edx			; decrement exponent
		cmp edx, 1		; compare exponent to 1
		jg power_loop 		; if still >1, jump back to power_loop
	power_end:
		movdqa xmm0, xmm2 	; copy result to xmm0, not needed for input numbers anymore
		pshufd xmm1, xmm2, 0EEh ; shuffle results so that 2 higher are under 2 lower
		paddd xmm0, xmm1        ; add. this way xmm0[0] = xmm0[0]+xmm0[2] and xmm0[1] = xmm0[1]+xmm0[3]
		pshufd xmm1, xmm0, 1h  	; shuffle results again with another mask so that value from xmm0[0] is under value from xmm0[1]
		paddd xmm0, xmm1        ; add again
		movd eax, xmm0 		; lowest 4B is the sum we need to return via rax
ret
asm_power ENDP
END
