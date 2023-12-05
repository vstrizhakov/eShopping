import React, { useEffect } from "react";
import { Announce as AnnounceModel } from "../../api/catalogSlice";
import { HubConnectionBuilder } from "@microsoft/signalr";
import DistributionContainer from "./DistributionContainer";
import { RootState } from "../../../app/store";
import { ConnectedProps, connect } from "react-redux";
import { setAnnounce } from "./viewAnnounceSlice";
import { Badge, Col, ListGroup, ListGroupItem, Row } from "react-bootstrap";
import Product from "../Product";

const mapStateToProps = (state: RootState) => ({
    accessToken: state.auth.token,
});

const mapDispatchToProps = {
    setAnnounce,
};

const connector = connect(mapStateToProps, mapDispatchToProps);

type PropsFromRedux = ConnectedProps<typeof connector>;
interface IProps extends PropsFromRedux {
    announce: AnnounceModel,
};

const Announce: React.FC<IProps> = props => {
    const {
        announce,
        setAnnounce,
        accessToken,
    } = props;


    useEffect(() => {
        if (!announce.distributionId) {
            const connection = new HubConnectionBuilder()
                .withUrl("/api/catalog/ws", {
                    accessTokenFactory: () => accessToken!,
                })
                .withAutomaticReconnect()
                .build();

            let canceled = false;
            const task = (async function () {
                connection.on("announceUpdated", (announce: AnnounceModel) => {
                    setAnnounce(announce);
                });

                await connection.start();

                if (!canceled) {
                    await connection.invoke("subscribe", {
                        announceId: announce.id,
                    });
                }
            })();

            return () => {
                (async function () {
                    canceled = true;

                    await task;

                    await connection.stop()
                })();
            };
        }
    }, [announce, accessToken, setAnnounce]);

    const mainImage = announce.images[0];
    const createdAtDatetime = new Date(announce.createdAt);
    const announceName = `Анонс від ${createdAtDatetime.getDate()}.${createdAtDatetime.getMonth() + 1}.${createdAtDatetime.getFullYear()}, ${createdAtDatetime.toLocaleTimeString()}`;
    
    return (
        <>
            <Row className="mb-5">
                <Col>
                    <h4 className="d-flex justify-content-between align-items-center mb-3">
                        <span className="text-body-emphasis">{announceName}</span>
                        <Badge bg="info" pill className="fw-semibold">{announce.shop.name}</Badge>
                    </h4>
                    <img className="rounded" src={mainImage} width="100%" alt={announceName}/>
                </Col>
                <Col>
                    <h4 className="d-flex justify-content-between align-items-center mb-3">
                        <span className="text-body-emphasis">Позиції</span>
                        <Badge bg="secondary" pill className="fw-semibold">{announce.products.length}</Badge>
                    </h4>
                    <ListGroup>
                        {announce.products.map(product => (
                            // probably need to use product's card externally here instead of p-0 border-0
                            <ListGroupItem key={product.id} className="p-0 border-0">
                                <Product
                                    name={product.name}
                                    url={product.url}
                                    price={product.price.price}
                                    discountedPrice={product.price.discountedPrice}
                                    currencyName={product.price.currency.name}
                                    description={product.description}
                                />
                            </ListGroupItem>
                        ))}
                    </ListGroup>
                </Col>
            </Row>

            {announce.distributionId && (
                <DistributionContainer distributionId={announce.distributionId} />
            )}
        </>
    );
};

export default connector(Announce);