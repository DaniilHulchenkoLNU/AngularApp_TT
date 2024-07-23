import { Component } from '@angular/core';
import { CryptoService } from '../../../../service/crypto.service';
import { СryptoRate } from '../../../../models/User/СryptoRate';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  cryptoRate: СryptoRate[]=[];

  constructor(public cryptoService: CryptoService) { }

  ngOnInit(): void {
    this.cryptoService.getRates().subscribe((data: СryptoRate[]) => {
      this.cryptoRate = data;
      if (this.cryptoRate.length > 0) {
        console.log(this.cryptoRate[0].name);
      } else {
        console.log("Данные о криптовалютах не получены или список пуст");
      }
    });
  }

  saveRate(rate: СryptoRate): void {
    this.cryptoService.saveRate(rate).subscribe({
      next: (savedRate) => {
        // Обработка успешного сохранения
        console.log('Rate saved successfully:', savedRate);
      },
      error: (error: HttpErrorResponse) => {
        // Правильная обработка ошибки
        console.error('Error status:', error.status);
        console.error('Error message:', error.message);
        // Используйте error.error для доступа к телу ошибки, если оно есть
      }
    });

  }
}
