import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-tenant-form',
  templateUrl: './tenant-form.component.html',
  styleUrls: ['./tenant-form.component.css']
})
export class TenantFormComponent implements OnInit {

  @Input() propertyId: string;
  @Output() tenant = new EventEmitter<FormGroup>();
  constructor() { }

  tenantForm = new FormGroup({
    firstName: new FormControl(),
    lastName: new FormControl(),
    jobTitle: new FormControl(),
    phoneNumber: new FormControl(),
    nationality: new FormControl(),
    tenancyStartDate: new FormControl(),
    notes: new FormControl(),
    image: new FormControl()
  });

  addTenant() {
    this.tenant.emit(this.tenantForm.value);
  }

  ngOnInit() {
  }



}
