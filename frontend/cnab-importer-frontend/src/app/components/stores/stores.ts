import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { MatCardModule } from "@angular/material/card";
import { MatTableModule } from "@angular/material/table";
import { CnabService } from "../../services/cnab.service";

@Component({
  standalone: true,
  selector: 'app-stores',
  imports: [
    CommonModule,
    MatTableModule,
    MatCardModule
  ],
  templateUrl: './stores.html',
})
export class StoresComponent {
  stores: any[] = [];

  constructor(private cnabService: CnabService) {
    this.load();
  }

  async load() {
    this.stores = await this.cnabService.getStores() ?? [];
  }
}
