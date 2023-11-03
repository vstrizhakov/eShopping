import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { useGetAnnounceQuery } from "../../api/catalogSlice";
import Announce from "./Announce";
import { RootState } from "../../../app/store";
import { ConnectedProps, connect } from "react-redux";
import { setAnnounce } from "./viewAnnounceSlice";

const mapStateToProps = (state: RootState) => ({
    announce: state.viewAnnounce.announce,
});

const mapDispatchToProps = {
    setAnnounce,
};

const connector = connect(mapStateToProps, mapDispatchToProps);
type PropsFromRedux = ConnectedProps<typeof connector>;

const AnnounceContainer: React.FC<PropsFromRedux> = props => {
    const {
        announce,
        setAnnounce,
    } = props;

    const {
        announceId,
    } = useParams();

    const {
        data,
        isLoading,
        isSuccess,
    } = useGetAnnounceQuery(announceId!);

    useEffect(() => {
        if (data) {
            setAnnounce(data);
        }
    }, [data]);

    if (isLoading) {
        return <>"Завантаження..."</>;
    }

    if (!isSuccess) {
        return <>Під час завантаження сталася помилка</>;
    }

    if (!announce) {
        return null;
    }

    return <Announce announce={announce} />
};

export default connector(AnnounceContainer);