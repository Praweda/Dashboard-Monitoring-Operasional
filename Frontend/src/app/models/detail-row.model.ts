export type PaymentStatus = 'Selesai' | 'Diproses' | 'Tertunda';

export interface DetailRow {
  date: string;
  category: string;
  amount: string;
  status: PaymentStatus;
}
