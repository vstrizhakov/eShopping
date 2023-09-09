import React from "react";
import { Form as BootstrapForm, Button, Card, Col, InputGroup, Row } from "react-bootstrap";
import { Field, useField } from "react-final-form";
import Check from "../../components/Check";
import Select from "../../components/Select";
import TextField from "../../components/TextField";
import { useGetCurrenciesQuery, useGetShopsQuery } from "../api/catalogSlice";

export interface AddProductForm {
    shopId: string,
    name: string,
    url: string,
    price: number,
    currencyId: string,
    sale: boolean,
    discount: number,
}

const AddProduct: React.FC = () => {
    const {
        data: currencies,
    } = useGetCurrenciesQuery(undefined);

    const {
        data: shops,
    } = useGetShopsQuery(undefined);

    const {
        input: {
            value: sale,
        },
    } = useField("sale", {
        subscription: {
            value: true,
        },
    });

    return (
        <Card>
            <Card.Header>
                <strong>Нова позиція</strong>
            </Card.Header>
            <Card.Body>
                {/* <BootstrapForm.FloatingLabel label="Магазин" controlId="product-shop-id" className="mb-3">
                    <Field
                        name="shopId"
                        disabled={shops === undefined}
                        defaultValue={shops && shops.length > 0 && shops[0].id}
                        component={Select}>
                        {shops && shops.map(shop => (
                            <option key={shop.id} value={shop.id}>{shop.name}</option>
                        ))}
                    </Field>
                </BootstrapForm.FloatingLabel> */}

                <BootstrapForm.FloatingLabel label="Назва позиції" controlId="product-name" className="mb-3">
                    <Field
                        name="name"
                        placeholder="Назва позиції"
                        component={TextField}
                    />
                </BootstrapForm.FloatingLabel>

                <BootstrapForm.FloatingLabel label="Посилання" controlId="product-url" className="mb-3">
                    <Field
                        name="url"
                        placeholder="Посилання"
                        component={TextField}
                    />
                </BootstrapForm.FloatingLabel>

                <Row className="mb-1">
                    <Col xs={9}>
                        <BootstrapForm.FloatingLabel label="Ціна" controlId="product-price">
                            <Field
                                name="price"
                                placeholder="Ціна"
                                component={TextField}
                            />
                        </BootstrapForm.FloatingLabel>
                    </Col>
                    <Col xs={3}>
                        <BootstrapForm.FloatingLabel label="Валюта" controlId="product-currency-id">
                            <Field
                                name="currencyId"
                                defaultValue={currencies && currencies.length > 0 && currencies[0].id}
                                component={Select}>
                                {currencies && currencies.map(currency => (
                                    <option key={currency.id} value={currency.id}>{currency.name}</option>
                                ))}
                            </Field>
                        </BootstrapForm.FloatingLabel>
                    </Col>
                </Row>

                <BootstrapForm.Group controlId="product-sale" className="mb-3">
                    <Field
                        name="sale"
                        label="Діє знижка"
                        component={Check}
                    />
                </BootstrapForm.Group>

                {sale && (
                    <InputGroup className="mb-3">
                        <BootstrapForm.FloatingLabel label="Знижка" controlId="product-discount">
                            <Field
                                name="discount"
                                placeholder="Знижка"
                                component={TextField}
                            />
                        </BootstrapForm.FloatingLabel>
                        <InputGroup.Text>%</InputGroup.Text>
                    </InputGroup>
                )}

                <Button type="submit">Додати</Button>
            </Card.Body>
        </Card>
    );
};

export default AddProduct;