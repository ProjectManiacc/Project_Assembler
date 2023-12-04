<h3>Opis Projektu</h3>
<p>Celem projektu jest stworzenie efektywnego programu wyszukującego liczby Armstronga w zakresie podanym w parametrach uruchomieniowych. Liczby Armstronga to takie liczby, które są sumą potęg swoich cyfr, zgodnie z ilością cyfr w danej liczbie. W ramach projektu rozważane jest także wykorzystanie wektorowych instrukcji oraz wielowątkowości w celu zoptymalizowania działania programu.</p>
<h4>Jak to działa:</h4>
<ol>
	<li><h5>Użytkownika Interfejs:</h5>
		<ul>
			<li>a. Interfejs użytkownika napisany w języku C++ umożliwia użytkownikowi wprowadzenie liczb do 			analizy.</li>
		</ul>
	</li>
<li>Wektorowa Implementacja:</li>
<ul>
<li>a. Algorytm sprawdzania liczby Armstronga w assemblerze zostanie zoptymalizowany do wykorzystania wektorowych instrukcji, jeśli dostępne w danym środowisku.</li>
<li>b. W języku C++ wykorzystane będą odpowiednie biblioteki, np. SIMD (Single Instruction, Multiple Data) do obsługi operacji wektorowych.</li>
</ul>
</li>
<li>Wielowątkowa Implementacja:
<ul>
<li>a. Algorytm będzie przygotowany do wielowątkowego przetwarzania wielu liczb jednocześnie.</li>
<li>b. W języku C++ wykorzystane zostaną mechanizmy wielowątkowości, takie jak standardowa biblioteka wątków.
</li>
</ul>
</li>
<li>Wzór na obliczenia liczby Armstronga:
<ul>
<li>a. Algorytm w assemblerze będzie implementował wzór:</li>
</ul>
</li>
<p align="center">
<img src="https://prepinstadotcom.s3.ap-south-1.amazonaws.com/wp-content/uploads/2022/01/Armstrong-Number-in-C-1024x1024.png" width=400px height=400px>
</p>
</ol>

<p>Projekt zakłada, że kod w assemblerze będzie odpowiedzialny za efektywne przetwarzanie pojedynczych liczb, a kod w C++ będzie koordynować interakcję z użytkownikiem, przyjmowanie danych wejściowych, oraz wykorzystywanie wektorowych instrukcji i wielowątkowości.</p>