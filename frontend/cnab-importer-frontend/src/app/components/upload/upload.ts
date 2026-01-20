import { Component } from '@angular/core';
import {
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  FormControl
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { CnabService } from '../../services/cnab.service';

@Component({
  standalone: true,
  selector: 'app-upload',
  imports: [
    ReactiveFormsModule,
    MatCardModule,
    MatButtonModule
  ],
  templateUrl: './upload.html',
})
export class UploadComponent {

  form!: FormGroup<{
    file: FormControl<string | null>;
  }>;

  constructor(
    private fb: FormBuilder,
    private cnabService: CnabService
  ) {
    this.form = this.fb.group({
      file: new FormControl<string | null>(null),
    });
  }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    const file = input.files?.[0];
    if (!file) return;

    const reader = new FileReader();
    reader.onload = () => {
      this.form.patchValue({
        file: reader.result as string
      });
    };
    reader.readAsText(file);
  }

  upload(): void {
    const fileContent = this.form.value.file;
    if (!fileContent) return;

    this.cnabService.uploadCnab(fileContent);
  }
}
