import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyDocumentFormComponent } from './property-document-form.component';

describe('PropertyDocumentFormComponent', () => {
  let component: PropertyDocumentFormComponent;
  let fixture: ComponentFixture<PropertyDocumentFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropertyDocumentFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyDocumentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
