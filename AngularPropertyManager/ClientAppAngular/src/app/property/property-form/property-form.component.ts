import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PropertyService } from '../property.service';
import { Property } from '../property.model';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-property-form',
  templateUrl: './property-form.component.html',
  styleUrls: ['./property-form.component.css']
})
export class PropertyFormComponent implements OnInit {
  private propertyId: string;

  constructor(
    private route: ActivatedRoute,
    private propertyService: PropertyService,
    private _location: Location,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.propertyId = params.get("propertyId")
      if (this.propertyId.length > 0) {
        this.propertyService.getPropertyById(this.propertyId).subscribe((data: Property) => {
          this.propertyForm.patchValue(data);
        }, (error) => {
            console.error(error);
        });
      }
    })
  }

  propertyForm = new FormGroup({
    id: new FormControl(""),
    purchasePrice: new FormControl(''),
    createdDateTime: new FormControl(''),
    purchaseDate: new FormControl(''),
    updatedDateTime: new FormControl(''),
    address: new FormGroup({
      id: new FormControl(''),
      createdDateTime: new FormControl(''),
      updatedDateTime: new FormControl(''),
      line1: new FormControl(''),
      line2: new FormControl(""),
      line3: new FormControl(""),
      postCode: new FormControl(''),
      city: new FormControl("")
    })
  });

  onSubmit() {
    console.warn(this.propertyForm.value);
    this.propertyService.updateProperty(this.propertyId, this.propertyForm.value).subscribe((data) => {
      this.toastr.success("Portfolio updated", "Success");
      this.backClicked();
    }, (error) => {
        this.toastr.error(error, "Error");
        console.error(error);
    });
  }

  backClicked() {
    this._location.back();
  }
}
