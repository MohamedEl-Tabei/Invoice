import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryDetailsAdminPage } from './category-details-admin-page';

describe('CategoryDetailsAdminPage', () => {
  let component: CategoryDetailsAdminPage;
  let fixture: ComponentFixture<CategoryDetailsAdminPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CategoryDetailsAdminPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CategoryDetailsAdminPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
