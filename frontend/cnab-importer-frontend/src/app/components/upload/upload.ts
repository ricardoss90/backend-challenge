import { Component, inject } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { CnabService } from '../../services/cnab.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-upload',
  standalone: true,
  templateUrl: './upload.html',
  styleUrls: ['./upload.scss'],
  imports: [ReactiveFormsModule, CommonModule] // <- import required modules here
})
export class UploadComponent {
  form = new FormGroup({
    file: new FormControl<string | null>(null)
  });

  private cnabService = inject(CnabService);

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (!file) return;

    const reader = new FileReader();
    reader.onload = () => {
      this.form.patchValue({ file: reader.result as string | null });
    };
    reader.readAsText(file);
  }

  upload() {
    const fileContent = this.form.value.file;
    if (!fileContent) return;
    this.cnabService.uploadCnab(fileContent);
    alert('File uploaded!');
  }
}
