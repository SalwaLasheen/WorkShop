import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProfileService } from 'src/app/_services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})

export class ProfileComponent implements OnInit {

  formGroup!: FormGroup;
  DialField: FormControl = new FormControl;
  SourceIdField: FormControl = new FormControl;
  LangIdField: FormControl = new FormControl;
  response: any;

  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    public service: ProfileService) {
  }

  ngOnInit() {
    this.loadForm();
  }

  loadForm() {
    this.formGroup = this.fb.group({
      DialField: ["", [Validators.required]],
      SourceIdField: [""],
      LangIdField: [""],
      DialOption:["01200000001"]
    });
  }

  Clear() {
      this.formGroup.reset();
       this.loadForm();
  }

  AddNewProfile() {
    if (this.formGroup.invalid) {
      this.HandleConditionalForm();
      return
    }
    const dial=this.formGroup.controls['DialOption'].value;
    this.formGroup.controls['DialField'].setValue(dial);
    return this.service.createNewProfile(this.formGroup.value)
      .subscribe((res) => {
       this.response=res;
        this.showToasterSuccess("Successfully Posted");
      },
        err => {
          console.log(err);
          this.showToasterError(err.error);
        });
  }
  HandleConditionalForm(): any {
    if (this.formGroup.get("dialField")?.invalid)
      return this.showToasterError('Invalid Dial Number');
  }
  showToasterError(message: string) {
   return this.toastr.error(message)
  }

  public showToasterSuccess(message: string) {
   return this.toastr.success(message)
  }
  onChange(value: any) {
  {

  this.formGroup.controls['DialField'].setValue(value);
  this.formGroup.controls['SourceIdField'].setValue("28");
  this.formGroup.controls['LangIdField'].setValue("1");
  }
}
}
