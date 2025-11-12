import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubCategoriesDetailsAdminPage } from './sub-categories-details-admin-page';

describe('SubCategoriesDetailsAdminPage', () => {
  let component: SubCategoriesDetailsAdminPage;
  let fixture: ComponentFixture<SubCategoriesDetailsAdminPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SubCategoriesDetailsAdminPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubCategoriesDetailsAdminPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
