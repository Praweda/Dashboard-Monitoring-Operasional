import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TableModule } from 'primeng/table';
import { ChartModule } from 'primeng/chart';
import { AppConfigService } from '../../app-config.service';
import { ApiResponse } from '../../dto/api-response.dto';
import { PaymentAndHistoryMonitoringModel } from '../../models/payment-and-history-monitoring.model';
import { PaymentAndHistoryModel } from '../../models/payment-and-history.model';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [TableModule, ChartModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
  apiErrorMessage = '';
  readonly periods = ['Harian', 'Mingguan', 'Bulanan'];
  selectedPeriod = 'Bulanan';
  readonly tableSize: 'small' | 'large' = 'small';
  paymentAndHistoryMonitoring: PaymentAndHistoryMonitoringModel[] = [];
  listDataMonitorOutgoing: PaymentAndHistoryMonitoringModel[] = [];
  listDataMonitorIncoming: PaymentAndHistoryMonitoringModel[] = [];
  paymentAndHistory: PaymentAndHistoryModel[] = [];
  listDataIncoming: PaymentAndHistoryModel[] = [];
  listDataOutgoing: PaymentAndHistoryModel[] = [];
  outgoingRows: PaymentAndHistoryModel[] = [];
  incomingRows: PaymentAndHistoryModel[] = [];
  readonly lineChartData = {
    labels: ['10 Okt', '11 Okt', '12 Okt', '13 Okt', '14 Okt'],
    datasets: [
      {
        label: 'Series Incoming',
        data: [4.5, 3.2, 4.0, 4.8, 5.35],
        borderColor: '#00683e',
        backgroundColor: '#00683e',
        tension: 0,
        fill: false,
        pointRadius: 0,
        pointHoverRadius: 5
      },
      {
        label: 'Series Outgoing',
        data: [2.7, 5.0, 2.2, 2.85, 3.68],
        borderColor: '#41d498',
        backgroundColor: '#41d498',
        tension: 0,
        fill: false,
        pointRadius: 0,
        pointHoverRadius: 5
      },
      {
        label: 'Series Rata-rata',
        data: [3.6, 4.1, 3.1, 4.0, 4.52],
        borderColor: '#c4c8cb',
        backgroundColor: '#c4c8cb',
        tension: 0,
        fill: false,
        pointRadius: 0,
        pointHoverRadius: 5
      }
    ]
  };

  readonly lineChartOptions = {
    maintainAspectRatio: false,
    layout: {
      padding: {
        top: 18,
        right: 28,
        bottom: 0,
        left: 18
      }
    },
    plugins: {
      legend: {
        position: 'bottom',
        labels: {
          color: '#121417',
          usePointStyle: true,
          pointStyle: 'circle',
          boxWidth: 8,
          boxHeight: 8,
          padding: 30
        }
      },
      tooltip: {
        mode: 'index',
        intersect: false
      }
    },
    interaction: {
      mode: 'nearest',
      axis: 'x',
      intersect: false
    },
    scales: {
      x: {
        ticks: {
          color: '#6b706b'
        },
        grid: {
          display: false,
          drawBorder: false
        },
        border: {
          color: '#b8c7d9'
        }
      },
      y: {
        min: 0,
        max: 6,
        ticks: {
          color: '#6b706b',
          stepSize: 1
        },
        grid: {
          color: '#dfe6f0',
          drawBorder: false
        },
        border: {
          display: false
        }
      }
    },
    elements: {
      line: {
        borderWidth: 3
      }
    }
  };

  constructor(
    private readonly http: HttpClient,
    private readonly appConfig: AppConfigService,
    private readonly changeDetector: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.GetAllDataPaymentAndHistory();
    this.GetAllDataPaymentAndHistoryMonitoring();
  }

  selectPeriod(period: string): void {
    this.selectedPeriod = period;
  }

  displayValue(value: string | number | null): string {
    return value === null || value === '' ? '-' : value.toString();
  }

  displayDate(value: string | null): string {
    return value ? value.substring(0, 10) : '-';
  }

  displayAmount(value: number | null): string {
    return value === null ? '-' : new Intl.NumberFormat('id-ID').format(value);
  }

  private updateOutgoingRows(rows: PaymentAndHistoryModel[]): void {
    setTimeout(() => {
      this.outgoingRows = [...rows];
      this.changeDetector.detectChanges();
    }, 0);
  }

  private updateIncomingRows(rows: PaymentAndHistoryModel[]): void {
    setTimeout(() => {
      this.incomingRows = [...rows];
      this.changeDetector.detectChanges();
    }, 0);
  }

  private GetAllDataPaymentAndHistory(): void {
    this.http
      .get<ApiResponse<PaymentAndHistoryModel[]>>(`${this.appConfig.apiBaseUrl}/PaymentAndHistory/GetAll`)
      .subscribe({
        next: (response) => {
          this.paymentAndHistory = response.result ?? [];
          this.loadDataOutgoing();
          this.loadDataIncoming();
          this.apiErrorMessage = '';
          console.log('payment and history:', this.paymentAndHistory);
        },
        error: () => {
          this.paymentAndHistory = [];
          this.apiErrorMessage = 'Failed to connect with backend.';
          console.log(this.apiErrorMessage);
        }
      });
  }

  private GetAllDataPaymentAndHistoryMonitoring(): void {
    this.http
      .get<ApiResponse<PaymentAndHistoryMonitoringModel[]>>(`${this.appConfig.apiBaseUrl}/PaymentAndHistoryMonitoring/GetAll`)
      .subscribe({
        next: (response) => {
          this.paymentAndHistoryMonitoring = response.result ?? [];
          this.loadDataMonitorOutgoing();
          this.loadDataMonitorIncoming();
          this.apiErrorMessage = '';
          console.log('payment and history monitoring:', this.paymentAndHistoryMonitoring);
        },
        error: () => {
          this.paymentAndHistoryMonitoring = [];
          this.apiErrorMessage = 'Failed to connect with backend.';
          console.log(this.apiErrorMessage);
        }
      });
  }

  loadDataOutgoing(): void {
    try {
      this.listDataOutgoing = this.paymentAndHistory.filter(payment => payment.io?.toLowerCase() === 'outgoing');
      this.updateOutgoingRows(this.listDataOutgoing);
      console.log('list data outgoing:', this.listDataOutgoing);
    }
    catch (error) {
      this.listDataOutgoing = [];
      this.updateOutgoingRows([]);
      console.error('Failed to load Outgoing list monitor.', error);
    }
  }

  loadDataIncoming(): void {
    try {
      this.listDataIncoming = this.paymentAndHistory.filter(payment => payment.io?.toLowerCase() === 'incoming');
      this.updateIncomingRows(this.listDataIncoming);
      console.log('list data Incoming:', this.listDataIncoming);
    }
    catch (error) {
      this.listDataIncoming = [];
      this.updateIncomingRows([]);
      console.error('Failed to load Incoming list monitor.', error);
    }
  }

  loadDataMonitorOutgoing(): void {
    try {
      this.listDataMonitorOutgoing = this.paymentAndHistoryMonitoring.filter(payment => payment.io?.toLowerCase() === 'outgoing');
      console.log('list data monitor outgoing:', this.listDataMonitorOutgoing);
    }
    catch (error) {
      this.listDataMonitorOutgoing = [];
      console.error('Failed to load Outgoing list monitor.', error);
    }
  }

  loadDataMonitorIncoming(): void {
    try {
      this.listDataMonitorIncoming = this.paymentAndHistoryMonitoring.filter(payment => payment.io?.toLowerCase() === 'incoming');
      console.log('list data monitor incoming:', this.listDataMonitorIncoming);
    }
    catch (error) {
      this.listDataMonitorIncoming = [];
      console.error('Failed to load Incoming list monitor.', error);
    }
  }
}
