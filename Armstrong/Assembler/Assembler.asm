.data
const_1 dd 1.0
const_0 dd 0.0
;exponent db 0

.code
asm_power PROC	
	movdqu xmm0, [rcx]	;za³adownaie do xmm0 zawartosci cyfr
	mov ecx, edx		;zaladowanie tablicy wykladnikow poteg
	movdqu xmm2, xmm0	;kopia cyfr do rejestru z wynikami
	
	cmp ecx, 1			; porownywanie ecx i 1 
	jle power_end     ; skocz do etykiety jesli jest mniejsze lub równe
	power_loop:
		pmulld xmm2, xmm0 ; mnozymy liczbe przez siebie
		dec ecx		; dekrementacja naszego wykladnika
		cmp ecx, 1	; porownanie wykladnika potegi do 1, ecx -1 do akumulatora
		jg power_loop ; skocz do power_loop jesli w akumulatroze jest wieksze od 0 


	power_end:
		movdqa xmm0, xmm2 ; kopiujemy nasz rezultat z pomnozonymi cyframi do xmm0

		pshufd xmm1, xmm2, 0EEh ; Przesuñ górne dwie liczby do dolnych dwóch slotów
		paddd xmm0, xmm1        ; Dodaj te liczby do oryginalnych dwóch liczb w xmm0
		pshufd xmm1, xmm0, 1h  ; Przesuñ drug¹ liczbê na pierwsz¹ pozycjê
		paddd xmm0, xmm1        ; Dodaj drug¹ liczbê do pierwszej
		; xmm0 jest rezultat

		movd eax, xmm0 ; przesuwany rezultat do rejestru eax

ret
asm_power ENDP
END