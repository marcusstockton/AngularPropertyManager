import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyDocumentListComponent } from './property-document-list.component';

describe('PropertyDocumentListComponent', () => {
  let component: PropertyDocumentListComponent;
  let fixture: ComponentFixture<PropertyDocumentListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropertyDocumentListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyDocumentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
