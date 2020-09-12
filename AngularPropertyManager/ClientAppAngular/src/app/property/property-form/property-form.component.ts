import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PropertyService } from '../property.service';
import { Property, Address } from '../property.model';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-property-form',
  templateUrl: './property-form.component.html',
  styleUrls: ['./property-form.component.css']
})
export class PropertyFormComponent implements OnInit {
  public propertyId: string;
  private portfolioId: string;
  images = [];

  constructor(
    private route: ActivatedRoute,
    private propertyService: PropertyService,
    private _location: Location,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.propertyId = params.get("propertyId");
      this.portfolioId = params.get("portfolioId");

      if (this.propertyId) {
        this.propertyService.getPropertyById(this.propertyId)
          .subscribe((data: Property) => {
            this.propertyForm.patchValue(data);
            const purchaseDate = new Date(data.purchaseDate).toISOString().substring(0, 10);
            this.propertyForm.controls["purchaseDate"].setValue(purchaseDate);
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
    images: new FormControl(''),
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
    const formData = new FormData();

    let files = this.propertyForm.get("images").value;
    for (let i = 0; i < files.length; i++) {
      formData.append("images", files[i], files[i].name)
    }

    formData.append("id", this.propertyForm.get("id").value);
    formData.append("createdDateTime", this.propertyForm.get("createdDateTime").value);
    formData.append("updatedDateTime", this.propertyForm.get("updatedDateTime").value);
    formData.append("purchaseDate", this.propertyForm.get("purchaseDate").value);
    formData.append("purchasePrice", this.propertyForm.get("purchasePrice").value);

    let address: Address = this.propertyForm.get("address").value;
    formData.append("address.id", address.id);
    formData.append("address.line1", address.line1);
    formData.append("address.line2", address.line2);
    formData.append("address.line3", address.line3);
    formData.append("address.city", address.city);
    formData.append("address.postCode", address.postCode);
    formData.append("address.createdDateTime", address.createdDateTime.toString());
    formData.append("address.updatedDateTime", address.updatedDateTime.toString());

    if (this.propertyId) {
      this.propertyService.updateProperty(this.propertyId, formData).subscribe((data) => {
        this.toastr.success("Portfolio updated", "Success");
        this.backClicked();
      }, (error) => {
        this.toastr.error(error, "Error");
        console.error(error);
      });
    } else {
      // Post
      this.propertyService.createProperty(this.portfolioId, this.propertyForm.value).subscribe((data) => {
        this.toastr.success("Property created.", "Success");
        this.backClicked();
      }, (error) => {
        this.toastr.error(error.statusText, "Error");
        console.error(error);
      });
    }

  }
  onFileSelect(event) {
    if (event.target.files && event.target.files[0]) {
      var filesAmount = event.target.files.length;
      for (let i = 0; i < filesAmount; i++) {
        var reader = new FileReader();

        reader.onload = (event: any) => {
          this.images.push(event.target.result);
        }

        reader.readAsDataURL(event.target.files[i]);
      }
      this.propertyForm.patchValue({
        images: event.target.files
      });
    }
  }

  tenantForm(event) {
    alert("Tenant stuff: " + event.firstName);
  }

  backClicked() {
    this._location.back();
  }
}
