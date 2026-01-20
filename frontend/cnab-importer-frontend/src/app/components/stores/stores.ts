import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CnabService } from '../../services/cnab.service';

@Component({
  selector: 'app-stores',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './stores.html'
})
export class StoresComponent {
  stores: any[] = []; // default empty array

  constructor(private cnabService: CnabService) {}

  async ngOnInit() {
    this.stores = (await this.cnabService.getStores()) || [];
  }

  getTotalValue(store: any): number {
    return store.transactions?.reduce((sum: number, t: any) => sum + t.value, 0) || 0;
  }
}
