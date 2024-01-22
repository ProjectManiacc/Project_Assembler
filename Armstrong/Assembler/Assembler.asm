.data
const_1 dd 1.0
const_0 dd 0.0
;exponent db 0

.code
asm_power PROC	
	movdqu xmm0, xmmword ptr [rcx]
	movdqu xmm1, xmmword ptr [rdx]

	cvtdq2ps xmm0, xmm0
	cvtdq2ps xmm1, xmm1

	vbroadcastss xmm2, [const_1] ;Put 1 mask
	vbroadcastss xmm3, [const_0] ;Put 0 mask


;xmm0 wektor na cyfry
	;xmm1 wektor wykladnika
	;xmm2 wektor jedynek
	;xmm3 wektor zera
	;xmm4 tymczasowy wynik	
	;xmm5 wektor prawdy i fa³szu
	power:
		vcmpps xmm5, xmm1, xmm3, 0 ;Testing if the vector is 0
		vptest xmm5, xmm5
		;mov rax, xmm5
		jnz exitpower
		vmulps xmm4, xmm4, xmm0
		vsubps xmm1, xmm1, xmm2
		jmp power
	exitpower:
cvtps2dq xmm0, xmm0
movdqu xmmword ptr [rcx], xmm4

ret
asm_power ENDP
END