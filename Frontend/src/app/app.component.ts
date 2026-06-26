import { Component } from '@angular/core';

interface DetailRow {
  date: string;
  category: string;
  amount: string;
  status: 'Selesai' | 'Diproses' | 'Tertunda';
}

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  readonly periods = ['Harian', 'Mingguan', 'Bulanan'];
  selectedPeriod = 'Bulanan';

  readonly outgoingRows: DetailRow[] = [
    { date: '10 Okt 2023', category: 'Produk A', amount: '2.500.000', status: 'Selesai' },
    { date: '11 Okt 2023', category: 'Produk B', amount: '1.250.000', status: 'Diproses' },
    { date: '12 Okt 2023', category: 'Produk A', amount: '3.100.000', status: 'Selesai' },
    { date: '13 Okt 2023', category: 'Lainnya', amount: '850.000', status: 'Tertunda' },
    { date: '14 Okt 2023', category: 'Produk B', amount: '4.200.000', status: 'Selesai' }
  ];

  readonly incomingRows: DetailRow[] = [
    { date: '10 Okt 2023', category: 'Produk A', amount: '1.500.000', status: 'Selesai' },
    { date: '11 Okt 2023', category: 'Produk B', amount: '850.000', status: 'Diproses' },
    { date: '12 Okt 2023', category: 'Produk A', amount: '2.100.000', status: 'Selesai' },
    { date: '13 Okt 2023', category: 'Lainnya', amount: '450.000', status: 'Tertunda' },
    { date: '14 Okt 2023', category: 'Produk B', amount: '3.200.000', status: 'Selesai' }
  ];

  selectPeriod(period: string): void {
    this.selectedPeriod = period;
  }
}
